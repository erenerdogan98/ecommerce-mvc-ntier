using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_Ecommerce_BLL.Abstract
{
    public interface IMovieService
    {
        Task AddMovie(Movie movie);
        Task RemoveMovie(Movie movie);
        Task<IEnumerable<Movie>> GetAllMovies();
        Task UpdateMovie(Movie movie);
        Task GetMovieById(int id);
    }
}
