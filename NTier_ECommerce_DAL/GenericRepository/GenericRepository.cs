using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NTier_ECommerce_DAL.Database;
using NTier_ECommerce_Entities;
using System.Linq.Expressions;


namespace NTier_ECommerce_DAL.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase, new()
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private IQueryable<T> QueryWithIncludes(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            _context.Entry(entity).State = EntityState.Deleted;
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await QueryWithIncludes().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties) =>
            await QueryWithIncludes(includeProperties).ToListAsync();

        public async Task<T> GetByIdAsync(int id) =>
            await QueryWithIncludes().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties) =>
            await QueryWithIncludes(includeProperties).FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

/*  EXPLANATION 
 * It is a class that implements a generic database repository and performs generic CRUD (Create, Read, Update, Delete) operations for types that use this interface. 
 * Below I explain the function of each method separately:
 
 ** Constructor (GenericRepository(Context context)):
It is the constructor method of the class.
It takes an object of type Context and initializes the _context field with this object.
If the incoming context value is null, an ArgumentNullException is thrown.

 ** QueryWithIncludes Method:
This method creates a query using Linq expressions on the specified entity type.
The includeProperties parameter specifies the associated entity properties to include in the query.
For example, using the GetAllAsync(params Expression<Func<T, object>>[] includeProperties) method includes the properties of related entities in the result of the query.

 ** SaveChangesAsync Method:
This asynchronous method is used to save changes to the _context object to the database.
The reason why this method is asynchronous is that database operations are usually performed asynchronously.

 ** AddAsync Method:
It is used to add a new entity. The entity parameter represents the entity to be added.
Changes are saved to the database with the SaveChangesAsync method.

 ** DeleteAsync Method:
It is used to delete assets.
The id parameter represents the ID of the entity to be deleted.
The entity is marked as EntityState.Deleted and the changes are saved to the database with the SaveChangesAsync method.

 ** GetAllAsync Method:
It is used to bring all entities.
If the includeProperties parameter is specified, the properties of the associated entities are also fetched.

 ** GetByIdAsync Method:
It is used to fetch the entity with a specific identity.
If the includeProperties parameter is specified, the properties of the associated entities are also fetched.
 
 ** UpdateAsync Method:
It is used to update the entity.
The id parameter represents the ID of the entity to be updated.
The entity parameter represents the updated data.
The entity is marked as EntityState.Modified and the changes are saved to the database with the SaveChangesAsync method.

 ******* This class is designed to support general CRUD operations and provide a reusable structure.
 */