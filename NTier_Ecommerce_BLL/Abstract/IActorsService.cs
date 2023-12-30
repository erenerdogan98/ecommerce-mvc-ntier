using NTier_ECommerce_Entities;

namespace NTier_Ecommerce_BLL.Abstract
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
