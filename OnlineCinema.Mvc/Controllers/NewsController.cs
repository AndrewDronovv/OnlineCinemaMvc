using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Domain;
using OnlineCinema.Mvc.Models.ViewModels.News;

namespace OnlineCinema.Mvc.Controllers;

public class NewsController : BaseMvcController
{
    public NewsController(IMapper mapper, AppDbContext context) : base(mapper, context)
    {
    }

    [Route("news/{id:int}")]
    public async Task<IActionResult> GetNewsById(int? id)
    {
        if (id == null || id < 0)
        {
            return NotFound();
        }

        try
        {
            var newsViewModel = await Context.News
                .ProjectTo<NewsViewModel>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (newsViewModel == null)
            {
                return NotFound();
            }

            return View("News", newsViewModel);
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }
}
