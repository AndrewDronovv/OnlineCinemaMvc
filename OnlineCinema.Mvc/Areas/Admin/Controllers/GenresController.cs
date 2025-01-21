using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Domain;
using OnlineCinema.Domain.Entities;
using OnlineCinema.Mvc.Controllers;
using OnlineCinema.Mvc.Models.Dto.Common;
using OnlineCinema.Mvc.Models.Dto.Genres;

namespace OnlineCinema.Mvc.Areas.Admin.Controllers;

[Authorize(Roles = "admin")]
[Area("Admin")]
public sealed class GenresController : BaseMvcController
{
    public GenresController(IMapper mapper, AppDbContext context) : base(mapper, context)
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GetAll([FromBody] PagedSearchRequestDto input)
    {
        IQueryable<Genre> query = Context.Genres;
        if (!string.IsNullOrWhiteSpace(input.Keyword))
        {
            query = query.Where(g => g.Name.ToLower().Contains(input.Keyword.ToLower()));
        }

        var totalCount = query.LongCount();

        var entities = query
            .Skip(input.SkipCount)
            .Take(input.PageSize)
            .ToList();

        var dtos = Mapper.Map<IReadOnlyList<GenreDto>>(entities);
        return Ok(new PagedResultDto<GenreDto>(totalCount, dtos));
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        Genre genre = Context.Genres.FirstOrDefault(g => g.Id == id);
        if (genre == null)
        {
            return BadRequest();
        }

        Context.Genres.Remove(genre);
        Context.SaveChanges();

        return Ok();
    }

    [HttpPut]
    public IActionResult Update([FromBody] GenreDto updateGenreDto)
    {
        var genre = Context.Genres.FirstOrDefault(g => g.Id == updateGenreDto.Id);
        if (genre == null)
        {
            return BadRequest();
        }

        Mapper.Map(updateGenreDto, genre);
        Context.SaveChanges();

        return Ok();
    }
}
