using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Domain;
using OnlineCinema.Mvc.Models.ViewModels.Movies;

namespace OnlineCinema.Mvc.Controllers;


public class MoviesController : BaseMvcController
{
    public MoviesController(IMapper mapper, AppDbContext context) : base(mapper, context)
    {
    }

    [Route("movies/{id:int}")]
    public async Task<IActionResult> Get(int? id)
    {
        if (id == null || id < 0)
        {
            return NotFound();
        }

        try
        {
            //Маппинг Movie в MovieViewModel через метод расширение ProjectTo()
            var movieViewModel = await Context.Movies
                .ProjectTo<MovieViewModel>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movieViewModel == null)
            {
                return NotFound();
            }

            return View("Movie", movieViewModel);
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }

    [Route("kids")]
    public async Task<IActionResult> KidsMovies()
    {
        var movies = await Context.Movies
            .Where(m => m.AgeRating <= 12)
            .ToListAsync();

        var kidsViewModel = Mapper.Map<IEnumerable<KidsViewModel>>(movies);

        if (kidsViewModel == null)
        {
            return NotFound();
        }

        return View("KidsMovies", kidsViewModel);
    }

    [Route("art")]
    public async Task<IActionResult> ArtMovies()
    {
        var movies = await Context.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .Where(m => m.MovieGenres
            .Any(mg => mg.GenreId == 5 || mg.GenreId == 10))
            .ToListAsync();

        var movieViewModels = Mapper.Map<IEnumerable<ArtViewModel>>(movies);

        if (movieViewModels == null)
        {
            return NotFound();
        }

        return View("ArtMovies", movieViewModels);
    }
}