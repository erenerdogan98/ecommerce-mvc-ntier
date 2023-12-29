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
        public void AddMovie(Movie movie);
        public void RemoveMovie(Movie movie);
        public IEnumerable<Movie> GetAllMovies();
        public void UpdateMovie(Movie movie);
        Movie GetMovieById(int id);
    }
}
