using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.EFRepository;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_Ecommerce_BLL.Concrete
{
    public class ActorsManager : IActorsService
    {
        private readonly EFActorsRepository eFActorsRepository;

        public ActorsManager(EFActorsRepository eFActorsRepository)
        {
            this.eFActorsRepository = eFActorsRepository ?? throw new ArgumentNullException(nameof(eFActorsRepository));
        }

        public Task AddActorAsync(Actors actor) => eFActorsRepository.AddAsync(actor);


        public Task<Actors> GetActorByIdAsync(int actorId) => eFActorsRepository.GetByIdAsync(actorId);

        public Task<IEnumerable<Actors>> GetAllActorsAsync() => eFActorsRepository.GetAllAsync();

        public Task RemoveActorAsync(Actors actor) => eFActorsRepository.DeleteAsync(actor.Id);

        public Task UpdateActorAsync(Actors actor) => eFActorsRepository.UpdateAsync(actor.Id, actor);
    }
}
/* 
 ORM (Object-Relational Mapping) tools such as Entity Framework are used to abstract your application's database connection, making it easier to migrate to a different database.
Therefore, creating repository classes that perform database operations using Entity Framework is a good approach to create a code base that follows layered architecture principles and is prepared for future changes.
 */
