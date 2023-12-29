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
        public void AddCinema(Cinema cinema);
        public void RemoveCinema(Cinema cinema);
        public void UpdateCinema(Cinema cinema);
        public IEnumerable<Cinema> GetAllCinema();  
        Cinema GetCinemaById(int id);

    }
}
