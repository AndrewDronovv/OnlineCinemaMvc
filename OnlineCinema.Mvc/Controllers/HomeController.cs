using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Domain;
using OnlineCinema.Mvc.Models.ViewModels.Home;

namespace OnlineCinema.Mvc.Controllers;

public class HomeController : BaseMvcController
{
    public HomeController(IMapper mapper, AppDbContext context) : base(mapper, context)
    {
    }

    public async Task<IActionResult> Index()
    {
        var homeViewModel = new HomeViewModel
        {
            Advertisings = await Context.Advertisings
                .Select(a => a.PathToImage)
                .ToListAsync(),
            Posters = Context.Movies
                .Where(m => m.IsVisible == true)
                .Select(m => new HomePosterViewModel
                {
                    Id = m.Id,
                    Age = m.AgeRating,
                    Name = m.Name,
                    CardImagePath = m.CardImagePath
                }),
            Promotions = Context.Promotions
                .Select(p => new HomePromotionViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImagePath = p.ImagePath,
                    Description = p.Description,
                    ButtonText = p.ButtonText
                }),
            News = Context.News
                .Select(n => new HomeNewsViewModel
                {
                    Id = n.Id,
                    Name = n.Name,
                    ImagePath = n.ImagePath,
                    Date = n.Date
                }),
        };

        return View(homeViewModel);
    }
}
