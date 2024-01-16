using DTOLayer.MovieDto;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.Database;
using NTier_ECommerce_DAL.GenericRepository;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_ECommerce_DAL.EFRepository
{
    public class EFMovieRepository : GenericRepository<Movie>, IMovieDAL
    {
        public EFMovieRepository(Context context) : base(context)
        {
            
        }

        public Task AddNewMovieAsync(Movie data)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VMNewMovieDropdownsDTO> GetNewMovieDropdownsValues()
        {
            throw new NotImplementedException();
        }

        public Task UpdateMovieAsync(Movie data)
        {
            throw new NotImplementedException();
        }
    }
}
