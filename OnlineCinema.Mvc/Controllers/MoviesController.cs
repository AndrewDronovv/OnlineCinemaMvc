using AutoMapper;
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
    public async Task<IActionResult> GetMovieById(int? id)
    {
        if (id == null || id < 0)
        {
            return NotFound();
        }

        try
        {
            var movieViewModel = await Context.Movies
                .Where(m => m.Id == id)
                .Select(m => new MovieViewModel
                {
                    Name = m.Name,
                    Description = m.Description,
                    Duration = m.Duration,
                    Country = m.Country,
                    OriginalName = m.OriginalName,
                })
                .FirstOrDefaultAsync();

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
}