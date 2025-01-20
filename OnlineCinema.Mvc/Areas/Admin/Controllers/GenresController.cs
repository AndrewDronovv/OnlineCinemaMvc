using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Domain;
using OnlineCinema.Domain.Entities;
using OnlineCinema.Mvc.Controllers;
using OnlineCinema.Mvc.Models.Dto.Common;
using OnlineCinema.Mvc.Models.Dto.Genres;

namespace OnlineCinema.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public sealed class GenresController : BaseMvcController
    {
        public GenresController(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll(PagedSearchRequestDto input)
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
    }
}
