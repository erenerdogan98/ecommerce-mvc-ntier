using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_Entities;
using System.Linq.Expressions;


namespace NTier_Ecommerce_BLL.Concrete
{
    public class ActorsManager : IActorsService
    {
        //private readonly EFActorsRepository eFActorsRepository; 
        // we will use IActorsDAL because it will be more fast
        private readonly IActorsDAL _actorsDal;

        public ActorsManager(IActorsDAL actorsDAL)
        {
            _actorsDal = actorsDAL ?? throw new ArgumentNullException(nameof(actorsDAL));
        }

        public Task AddAsync(Actors actor) => _actorsDal.AddAsync(actor);

        public Task DeleteAsync(int id) => _actorsDal.DeleteAsync(id);

        public Task<IEnumerable<Actors>> GetAllAsync() => _actorsDal.GetAllAsync();

        public async Task<IEnumerable<Actors>> GetAllAsync(params Expression<Func<Actors, object>>[] includeProperties) =>
           await _actorsDal.GetAllAsync(includeProperties);

        public Task<Actors> GetByIdAsync(int id) => _actorsDal.GetByIdAsync(id);

        public async Task<Actors> GetByIdAsync(int id, params Expression<Func<Actors, object>>[] includeProperties) =>
           await _actorsDal.GetByIdAsync(id, includeProperties);

        Task IGenericService<Actors>.UpdateAsync(int id, Actors actor) => _actorsDal.UpdateAsync(actor.Id, actor);
    }
}
/* 
 ORM (Object-Relational Mapping) tools such as Entity Framework are used to abstract your application's database connection, making it easier to migrate to a different database.
Therefore, creating repository classes that perform database operations using Entity Framework is a good approach to create a code base that follows layered architecture principles and is prepared for future changes.
 */
