using DTOLayer.MovieDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_Entities;
using NTier_ECommerce_Entities.Static;
using NTier_ECommerce_UI.ViewModels;

namespace NTier_ECommerce_UI.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMovieService _moviesService;

        public MoviesController(IMovieService moviesService)
        {
            _moviesService = moviesService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _moviesService.GetAllAsync(x => x.Cinema);
            return View(allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _moviesService.GetAllAsync(x => x.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies
                    .Where(x => string.Equals(x.MovieName, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                string.Equals(x.MovieDescription, searchString, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();

                return View("Index", filteredResult);
            }

            return View("Index", allMovies);
        }

        //GET: Movies/Details/id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _moviesService.GetByIdAsync(id);
            return View(movieDetail);
        }

        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValues();
            PopulateDropdownsInViewBag(movieDropdownsData);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValues();
                PopulateDropdownsInViewBag(movieDropdownsData);

                return View(movie);
            }

            await _moviesService.AddAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _moviesService.GetByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = MapMovieToViewModel(movieDetails);

            var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValues();
            PopulateDropdownsInViewBag(movieDropdownsData);

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValues();
                PopulateDropdownsInViewBag(movieDropdownsData);

                return View(movie);
            }

            await _moviesService.UpdateAsync(id, movie);
            return RedirectToAction(nameof(Index));
        }

        private void PopulateDropdownsInViewBag(VMNewMovieDropdownsDTO movieDropdownsData)
        {
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
        }

        private VMNewMovie MapMovieToViewModel(Movie movie)
        {
            return new VMNewMovie
            {
                Id = movie.Id,
                Name = movie.MovieName,
                Description = movie.MovieDescription,
                Price = movie.Price,
                StartDate = movie.StartingDate,
                EndDate = movie.EndingDate,
                ImageURL = movie.MovieImageUrl,
                MovieCategory = movie.CategoryMovie,
                CinemaId = movie.CinemaId,
                ProducerId = movie.ProducerId,
                ActorIds = movie.Actors_Movies.Select(x => x.ActorId).ToList(),
            };
        }
    }
}
