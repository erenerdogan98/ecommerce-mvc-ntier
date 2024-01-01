using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.EFRepository;
using NTier_ECommerce_Entities;


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

        public Task AddActorAsync(Actors actor) => _actorsDal.AddAsync(actor);


        public Task<Actors> GetActorByIdAsync(int actorId) => _actorsDal.GetByIdAsync(actorId);

        public Task<IEnumerable<Actors>> GetAllActorsAsync() => _actorsDal.GetAllAsync();

        public Task RemoveActorAsync(Actors actor) => _actorsDal.DeleteAsync(actor.Id);

        public Task UpdateActorAsync(Actors actor) => _actorsDal.UpdateAsync(actor.Id, actor);
    }
}
/* 
 ORM (Object-Relational Mapping) tools such as Entity Framework are used to abstract your application's database connection, making it easier to migrate to a different database.
Therefore, creating repository classes that perform database operations using Entity Framework is a good approach to create a code base that follows layered architecture principles and is prepared for future changes.
 */
