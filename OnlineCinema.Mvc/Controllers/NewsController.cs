using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Domain;
using OnlineCinema.Mvc.Models.ViewModels.News;

namespace OnlineCinema.Mvc.Controllers
{
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
                    .Where(n => n.Id == id)
                    .Select(n => new NewsViewModel
                    {
                        Date = DateTime.Now,
                        ImagePath = n.ImagePath,
                        Name = n.Name,
                    })
                    .FirstOrDefaultAsync();

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
}
