using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Domain;
using OnlineCinema.Mvc.Models.ViewModels.Promotions;

namespace OnlineCinema.Mvc.Controllers;

[Route("promotions")]
public class PromotionsController : BaseMvcController
{
    public PromotionsController(IMapper mapper, AppDbContext context) : base(mapper, context)
    {
    }

    [Route("")]
    public async Task<IActionResult> Promo()
    {
        var viewModel = new PromotionsViewModel
        {
            Promotions = await Context.Promotions.Select(p => p).ToListAsync(),
        };

        return View(viewModel);
    }

    [Route("getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        //var promotion = await Context.Promotions.FirstOrDefaultAsync(n => n.Id == id);
        //if (promotion == null)
        //{
        //    return NotFound();
        //}

        ViewBag.PromoId = id;
        var viewModel = new PromotionsViewModel
        {
            Promotions = await Context.Promotions.ToListAsync(),
        };

        return View("PromotionDetails", viewModel);
    }
}