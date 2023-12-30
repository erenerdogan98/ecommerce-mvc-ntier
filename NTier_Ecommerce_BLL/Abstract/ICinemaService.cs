using NTier_ECommerce_DAL.GenericRepository;
using NTier_ECommerce_Entities;


namespace NTier_ECommerce_BLL.Abstract
{
    public interface ICinemaService 
    {
        Task AddCinema(Cinema cinema);
        Task RemoveCinema(Cinema cinema);
        Task UpdateCinema(Cinema cinema);
        Task<IEnumerable<Cinema>> GetAllCinema();  
        Task<Cinema> GetCinemaById(int id);

    }
}
