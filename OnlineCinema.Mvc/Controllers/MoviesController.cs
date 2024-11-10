using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Domain;
using OnlineCinema.Mvc.Models.ViewModels.Movies;

namespace OnlineCinema.Mvc.Controllers;

[Route("movies")]
public class MoviesController : BaseMvcController
{
    public MoviesController(IMapper mapper, AppDbContext context) : base(mapper, context)
    {
    }

    [HttpGet]
    [Route("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        if (id <= 0)
        {
            return BadRequest("Неверный id");
        }

        var movie = await Context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        ViewBag.MovieId = id;
        var viewModel = new MoviesViewModel
        {
            Movies = await Context.Movies.ToListAsync(),
        };

        return View("Movies", viewModel);
    }
}