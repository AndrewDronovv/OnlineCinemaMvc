using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Domain;
using OnlineCinema.Domain.Entities;
using OnlineCinema.Mvc.Controllers;
using OnlineCinema.Mvc.Models.Dto.Common;
using OnlineCinema.Mvc.Models.Dto.Genres;
using OnlineCinema.Mvc.Models.Dto.Promotions;

namespace OnlineCinema.Mvc.Areas.Admin.Controllers;

[Authorize(Roles = "admin")]
[Area("Admin")]
public sealed class PromotionsController : BaseMvcController
{
    public PromotionsController(IMapper mapper, AppDbContext context) : base(mapper, context)
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GetAll([FromBody] PagedSearchRequestDto input)
    {
        IQueryable<Promotion> query = Context.Promotions;
        if (!string.IsNullOrWhiteSpace(input.Keyword))
        {
            query = query.Where(g => g.Name.ToLower().Contains(input.Keyword.ToLower()));
        }

        var totalCount = query.LongCount();

        var entities = query
            .Skip(input.SkipCount)
            .Take(input.PageSize)
            .ToList();

        var dtos = Mapper.Map<IReadOnlyList<PromotionDto>>(entities);
        return Ok(new PagedResultDto<PromotionDto>(totalCount, dtos));
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        var promotion = Context.Promotions.FirstOrDefault(p => p.Id == id);

        if (promotion is null)
        {
            return BadRequest();
        }

        Context.Promotions.Remove(promotion);
        Context.SaveChanges();

        return Ok();
    }
}
