using NTier_Ecommerce_BLL.Abstract;
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
        private readonly EFMovieRepository _eFMovieRepository;
        public MovieManager(EFMovieRepository eFMovieRepository)
        {
            _eFMovieRepository = eFMovieRepository;
        }
        public Task AddMovie(Movie movie) => _eFMovieRepository.AddAsync(movie);

        public Task<IEnumerable<Movie>> GetAllMovies() => _eFMovieRepository.GetAllAsync();

        public Task GetMovieById(int id) => _eFMovieRepository.GetByIdAsync(id);

        public Task RemoveMovie(Movie movie) => _eFMovieRepository.DeleteAsync(movie.Id);

        public Task UpdateMovie(Movie movie) => _eFMovieRepository.UpdateAsync(movie.Id,movie);
    }
}
