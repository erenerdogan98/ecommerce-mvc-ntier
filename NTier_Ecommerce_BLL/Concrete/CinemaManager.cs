using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.EFRepository;
using NTier_ECommerce_Entities;
using System.Linq.Expressions;

namespace NTier_Ecommerce_BLL.Concrete
{
    public class CinemaManager : ICinemaService
    {
        //EFCinemaRepostiory _eFCinemaRepostiory;
        private readonly ICinemaDAL _cinemaDAL;
        public CinemaManager(ICinemaDAL cinemaDAL)
        {
            _cinemaDAL = cinemaDAL ?? throw new ArgumentNullException(nameof(cinemaDAL)); ;
        }

        public Task AddAsync(Cinema cinema) => _cinemaDAL.AddAsync(cinema);

        public Task DeleteAsync(int id) => _cinemaDAL.DeleteAsync(id);

        public Task<IEnumerable<Cinema>> GetAllAsync() => _cinemaDAL.GetAllAsync();

        public Task<IEnumerable<Cinema>> GetAllAsync(params Expression<Func<Cinema, object>>[] includeProperties) => _cinemaDAL.GetAllAsync(includeProperties);

        public Task<Cinema> GetByIdAsync(int id) => _cinemaDAL.GetByIdAsync(id);

        public Task<Cinema> GetByIdAsync(int id, params Expression<Func<Cinema, object>>[] includeProperties) => _cinemaDAL.GetByIdAsync(id, includeProperties);

        public Task UpdateAsync(int id, Cinema cinema) => _cinemaDAL.UpdateAsync(id, cinema);
        //public Task AddCinema(Cinema cinema) => _cinemaDAL.AddAsync(cinema);

        //public Task<IEnumerable<Cinema>> GetAllCinema() => _cinemaDAL.GetAllAsync();

        //public Task<Cinema> GetCinemaById(int id) => _cinemaDAL.GetByIdAsync(id);

        //public Task RemoveCinema(Cinema cinema) => _cinemaDAL.DeleteAsync(cinema.Id);

        //public Task UpdateCinema(Cinema cinema) => _cinemaDAL.UpdateAsync(cinema.Id, cinema);

    }
}
