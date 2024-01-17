using DTOLayer.MovieDto;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_Ecommerce_BLL.Abstract
{
    public interface IMovieService : IGenericService<Movie>
    {
        //Task AddMovie(Movie movie);
        //Task RemoveMovie(Movie movie);
        //Task<IEnumerable<Movie>> GetAllMovies();
        //Task UpdateMovie(Movie movie);
        //Task<Movie> GetMovieById(int id);
        Task AddNewMovieAsync(Movie data);
        Task<Movie> GetMovieByIdAsync(int id);
        Task UpdateMovieAsync(Movie data);
        Task<VMNewMovieDropdownsDTO> GetNewMovieDropdownsValues();
    }
}
