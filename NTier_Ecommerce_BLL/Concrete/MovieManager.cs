using DTOLayer.MovieDto;
using Microsoft.EntityFrameworkCore;
using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.Database;
using NTier_ECommerce_Entities;
using System.Linq.Expressions;

namespace NTier_Ecommerce_BLL.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieDAL _movieDAL;
        private readonly Context _context;
        public MovieManager(IMovieDAL movieDAL, Context context)
        {
            _movieDAL = movieDAL ?? throw new ArgumentNullException(nameof(movieDAL));
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }

        public async Task AddAsync(Movie movie) => await _movieDAL.AddAsync(movie);


        public async Task DeleteAsync(int id) => await _movieDAL.DeleteAsync(id);

        public async Task<IEnumerable<Movie>> GetAllAsync() => await _movieDAL.GetAllAsync();

        public async Task<IEnumerable<Movie>> GetAllAsync(params Expression<Func<Movie, object>>[] includeProperties) =>
            await _movieDAL.GetAllAsync(includeProperties);


        public async Task<Movie> GetByIdAsync(int id) => await _movieDAL.GetByIdAsync(id);

        public async Task<Movie> GetByIdAsync(int id, params Expression<Func<Movie, object>>[] includeProperties) =>
            await _movieDAL.GetByIdAsync(id, includeProperties);


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

        public async Task UpdateAsync(int id, Movie entity) => await _movieDAL.UpdateAsync(id, entity);
    }
}
/*  Explanation about this operations
 * Constructor method 
    This method is called when an instance of the MovieManager class is created.
It takes IMovieDAL and Context objects as parameters. These objects are the data access layer (DAL) 
and database context (Context) classes that will be used within the class.

 async Keyword:

The async keyword makes a method asynchronous. Asynchronous methods can continue other operations while waiting for one operation to complete.
Adding this keyword to the method declaration allows using the await keyword in it.

 await Keyword:

The await keyword calls an asynchronous method and waits for that method to complete. Thanks to this keyword, the program can wait until a certain operation is completed and continue other operations.
await can only be used in async methods.

 Task Class:

The Task class is a type that represents an asynchronous task. Task<T> represents an asynchronous task that returns a value.
async methods usually return a result of type Task or Task<T>.
The await keyword waits for an object of type Task or Task<T> to complete and retrieves the result.

 How async Methods Work:

An async method specifies that an operation will be performed asynchronously.
A method using await indicates that there is an asynchronous operation. At this point, it waits for this operation to complete and allows other operations.
Usage Scenario of async Methods:

It is useful for I/O operations (such as file reading/writing, network operations) or long-running operations.
It is used in UI (User Interface) programming to ensure that the user interface does not freeze.
It is preferred in cases where multiple operations must be performed simultaneously.

 
 DIFFERENCE BETWEEN         public async Task<IEnumerable<Movie>> GetAllAsync() => await _movieDAL.GetAllAsync();

        public async Task<IEnumerable<Movie>> GetAllAsync(params Expression<Func<Movie, object>>[] includeProperties) =>
            await _movieDAL.GetAllAsync(includeProperties); 
these methods
The includeProperties parameter is of type Expression<Func<Movie, object>>, and this expression specifies which bound properties to load.
This method can pull more data by taking into account linked relationships using the Include method. This allows data from related tables to be joined without using another SQL query.*/
