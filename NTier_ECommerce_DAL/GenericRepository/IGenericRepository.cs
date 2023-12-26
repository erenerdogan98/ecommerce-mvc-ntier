using NTier_ECommerce_Entities;
using System.Linq.Expressions;


namespace NTier_ECommerce_DAL.GenericRepository
{
    public interface IGenericRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
    }
}

/*  EXPLANATION
 *  It defines a generic database transaction interface (repository) to be used to carry out general database operations.
    This type of structure allows you to perform database operations in a reusable and generalized way.

 AddAsync Method:

It takes an entity of type T and asynchronously adds this entity to the database.
UpdateAsync Method:

It takes an id and an entity of type T and asynchronously updates the entity with that id.
DeleteAsync Method:

It takes an id and asynchronously deletes the entity with that id from the database.
GetAllAsync Method:

Asynchronously fetches all entities.
GetAllAsync Method (Overload):

Asynchronously fetches all entities and includes the specified linked entity properties.
GetByIdAsync Method:

It takes an id and asynchronously fetches the entity with that id.
GetByIdAsync Method (Overload):

It takes an id and asynchronously fetches the entity with that id, also containing the specified bound entity properties.
Notes:

The T class is expected to implement the IEntityBase interface. This ensures that entities have common properties.
The new() statement ensures that T has a parameterless constructor. This allows us to create an instance of it using the new T() expression.
This interface provides a general set of database operations, and these operations provide a general structure that can operate on different types of entities. For example, you can work with different asset types such as Movie or Cinema. In this way, you can use a general structure instead of writing database operations separately for each entity type.*/