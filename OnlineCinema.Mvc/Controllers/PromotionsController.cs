using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Domain;
using OnlineCinema.Mvc.Models.ViewModels.Promotions;

namespace OnlineCinema.Mvc.Controllers;

public class PromotionsController : BaseMvcController
{
    public PromotionsController(IMapper mapper, AppDbContext context) : base(mapper, context)
    {
    }

    [Route("promotions")]
    public async Task<IActionResult> Promotions()
    {
        try
        {
            var promotionsViewModel = await Context.Promotions
                .ProjectTo<PromotionViewModel>(Mapper.ConfigurationProvider)
                .ToListAsync();

            if (!promotionsViewModel.Any())
            {
                return NotFound();
            }

            return View("Promotions", promotionsViewModel);
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }

    [Route("promotions/{name}")]
    public async Task<IActionResult> Get(string name)
    {
        try
        {
            var promotionViewModel = await Context.Promotions
                .ProjectTo<PromotionViewModel>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Name == name);

            if (promotionViewModel == null)
            {
                return NotFound();
            }

            return View("PromotionDetails", promotionViewModel);
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }
}