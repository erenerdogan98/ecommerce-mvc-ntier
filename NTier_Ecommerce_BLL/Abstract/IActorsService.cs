using NTier_ECommerce_DAL.GenericRepository;
using NTier_ECommerce_Entities;


namespace NTier_ECommerce_DAL.Abstract
{
    public interface IActorsService
    {
        public void AddActor(Actors actor);
        public void RemoveActor(Actors actor);
        public void UpdateActor(Actors actor);
        public IEnumerable<Actors> GetAllActors();
        Actors GetActorById(int actorId);
    }
}
