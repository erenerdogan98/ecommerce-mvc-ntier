using NTier_Ecommerce_BLL.Abstract;
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
    public class MovieManager : IMovieService
    {
        //private readonly EFMovieRepository _eFMovieRepository;
        private readonly IMovieDAL _movieDAL;
        public MovieManager(IMovieDAL movieDAL)
        {
            _movieDAL = movieDAL ?? throw new ArgumentNullException(nameof(movieDAL));
        }
        public Task AddMovie(Movie movie) => _movieDAL.AddAsync(movie);

        public Task<IEnumerable<Movie>> GetAllMovies() => _movieDAL.GetAllAsync();

        public Task<Movie> GetMovieById(int id) => _movieDAL.GetByIdAsync(id);

        public Task RemoveMovie(Movie movie) => _movieDAL.DeleteAsync(movie.Id);

        public Task UpdateMovie(Movie movie) => _movieDAL.UpdateAsync(movie.Id,movie);
    }
}
