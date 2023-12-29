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
    public class CinemaManager : ICinemaService
    {
        EFCinemaRepostiory _eFCinemaRepostiory;
        public CinemaManager(EFCinemaRepostiory eFCinemaRepostiory)
        {
            _eFCinemaRepostiory = eFCinemaRepostiory ?? throw new ArgumentNullException(nameof(_eFCinemaRepostiory)); ;
        }
        public Task AddCinema(Cinema cinema) => _eFCinemaRepostiory.AddAsync(cinema);

        public Task<IEnumerable<Cinema>> GetAllCinema() => _eFCinemaRepostiory.GetAllAsync();

        public Task<Cinema> GetCinemaById(int id) => _eFCinemaRepostiory.GetByIdAsync(id);

        public Task RemoveCinema(Cinema cinema) => _eFCinemaRepostiory.DeleteAsync(cinema.Id);

        public Task UpdateCinema(Cinema cinema) => _eFCinemaRepostiory.UpdateAsync(cinema.Id, cinema);
        
    }
}
