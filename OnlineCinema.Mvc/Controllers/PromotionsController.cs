using AutoMapper;
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
            var promotions = await Context.Promotions
                .Select(p => new PromotionViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    DateTime = DateTime.Now,
                    ButtonText = p.ButtonText,
                    Description = p.Description,
                    ImagePath = p.ImagePath,
                })
                .ToListAsync();

            if (!promotions.Any())
            {
                return View("Акций в данный момент нет");
            }

            var promotionsViewModel = new PromotionsViewModel
            {
                Promotions = promotions
            };

            return View("Promotions", promotionsViewModel);
        }
        catch (Exception ex)
        {
            return View("Ошибка");
        }
    }

    [Route("promotions/{id:int}")]
    public async Task<IActionResult> GetPromotionById(int? id)
    {
        try
        {
            var promotionViewModel = await Context.Promotions
                .Where(p => p.Id == id)
                .Select(p => new PromotionViewModel
                {
                    Name = p.Name,
                    DateTime = DateTime.Now,
                    ButtonText = p.ButtonText,
                    Description = p.Description,
                    ImagePath = p.ImagePath,
                })
                .FirstOrDefaultAsync();

            if (promotionViewModel == null)
            {
                return View($"Акция с номером {id} не найдена");
            }

            return View("PromotionDetails", promotionViewModel);
        }
        catch (Exception ex)
        {
            return View("Ошибка");
        }
    }
}