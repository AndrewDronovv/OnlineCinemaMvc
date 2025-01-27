using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Domain;
using OnlineCinema.Mvc.Models.ViewModels.Orders;

namespace OnlineCinema.Mvc.Controllers;

public class OrdersController : BaseMvcController
{
    public OrdersController(IMapper mapper, AppDbContext context) : base(mapper, context)
    {
    }

    [Route("orders/{id:int}")]
    public async Task<IActionResult> Index(int id)
    {
        var orderViewModel = new OrderViewModel
        {
            Movie = await Context.Movies
                .AsNoTracking()
                .ProjectTo<OrderMovieViewModel>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(m => m.Id == id),
            Seat = await Context.Seats
                .AsNoTracking()
                .ProjectTo<OrderSeatViewModel>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(s => s.Id == id)
        };
        return View(orderViewModel);
    }
}