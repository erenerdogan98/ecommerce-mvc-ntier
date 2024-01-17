using DTOLayer.MovieDto;
using NTier_ECommerce_DAL.GenericRepository;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_ECommerce_DAL.Abstract
{
    public interface IMovieDAL : IGenericRepository<Movie>
    {
        Task AddNewMovieAsync(Movie data);
        Task<Movie> GetMovieByIdAsync(int id);
        Task UpdateMovieAsync(Movie data);
        Task<VMNewMovieDropdownsDTO> GetNewMovieDropdownsValues();
    }
}
