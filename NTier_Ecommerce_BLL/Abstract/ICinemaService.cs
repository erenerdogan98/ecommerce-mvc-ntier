using NTier_ECommerce_DAL.GenericRepository;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_ECommerce_DAL.Abstract
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
