using NTier_ECommerce_DAL.GenericRepository;
using NTier_ECommerce_Entities;


namespace NTier_ECommerce_DAL.Abstract
{
    public interface IActorsService
    {
        Task AddActorAsync(Actors actor);
        Task RemoveActorAsync(Actors actor);
        Task UpdateActorAsync(Actors actor);
        Task<IEnumerable<Actors>> GetAllActorsAsync();
        Task<Actors> GetActorByIdAsync(int actorId);
    }
}
