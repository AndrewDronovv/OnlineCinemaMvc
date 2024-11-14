using AutoMapper;
using AutoMapper.QueryableExtensions;
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
                .ProjectTo<HomePosterViewModel>(Mapper.ConfigurationProvider),
            Promotions = Context.Promotions
                .ProjectTo<HomePromotionViewModel>(Mapper.ConfigurationProvider),
            News = Context.News
                .ProjectTo<HomeNewsViewModel>(Mapper.ConfigurationProvider)
        };

        return View(homeViewModel);
    }
}
