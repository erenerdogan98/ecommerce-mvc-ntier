using DTOLayer.MovieDto;
using Microsoft.EntityFrameworkCore;
using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.Database;
using NTier_ECommerce_DAL.EFRepository;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTier_Ecommerce_BLL.Concrete
{
    public class MovieManager : IMovieService
    {
        //private readonly EFMovieRepository _eFMovieRepository;
        private readonly IMovieDAL _movieDAL;
        private readonly Context _context;
        public MovieManager(IMovieDAL movieDAL, Context context)
        {
            _movieDAL = movieDAL ?? throw new ArgumentNullException(nameof(movieDAL));
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }

        public Task AddAsync(Movie movie) => _movieDAL.AddAsync(movie);

        public Task AddNewMovieAsync(Movie data)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id) => _movieDAL.DeleteAsync(id);

        public Task<IEnumerable<Movie>> GetAllAsync() => _movieDAL.GetAllAsync();

        public async Task<IEnumerable<Movie>> GetAllAsync(params Expression<Func<Movie, object>>[] includeProperties)
        {
            return await _movieDAL.GetAllAsync(includeProperties);
        }

        public Task<Movie> GetByIdAsync(int id) => _movieDAL.GetByIdAsync(id);

        public async Task<Movie> GetByIdAsync(int id, params Expression<Func<Movie, object>>[] includeProperties)
        {
            return await _movieDAL.GetByIdAsync(id, includeProperties);
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _movieDAL.GetByIdAsync(id);
        }

        public async Task<VMNewMovieDropdownsDTO> GetNewMovieDropdownsValues()
        {
            var response = new VMNewMovieDropdownsDTO()
            {
                Actors = await _context.Actors.OrderBy(n => n.NameSurname).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.NameSurname).ToListAsync()
            };
            return response;
        }

        public Task UpdateAsync(int id, Movie entity) => _movieDAL.UpdateAsync(id, entity);

        public Task UpdateMovieAsync(Movie data)
        {
            throw new NotImplementedException();
        }
        //public Task AddMovie(Movie movie) => _movieDAL.AddAsync(movie);

        //public Task<IEnumerable<Movie>> GetAllMovies() => _movieDAL.GetAllAsync();

        //public Task<Movie> GetMovieById(int id) => _movieDAL.GetByIdAsync(id);

        //public Task RemoveMovie(Movie movie) => _movieDAL.DeleteAsync(movie.Id);

        //public Task UpdateMovie(Movie movie) => _movieDAL.UpdateAsync(movie.Id,movie);
    }
}
