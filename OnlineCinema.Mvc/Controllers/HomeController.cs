using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Domain;
using OnlineCinema.Mvc.Models;

namespace OnlineCinema.Mvc.Controllers
{
    public class HomeController : BaseMvcController
    {
        public HomeController(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Advertisings = Context.Advertisings.Select(a => a.PathToImage).ToList(),
                Posters = Context.Movies.Where(m => m.IsVisible == true).Select(p => new PosterViewModel
                {
                    Age = p.AgeRating,
                    Name = p.Name,
                    CardImagePath = p.CardImagePath,
                }),
                Promotions = Context.Promotions.Select(p => p).ToList(),
                News = Context.News.Select(n => n).ToList(),

            };
            return View(viewModel);
        }
    }
}
