﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Domain;
using OnlineCinema.Mvc.Models.ViewModels.Hall;

namespace OnlineCinema.Mvc.Controllers
{
    public class HallController : BaseMvcController
    {
        public HallController(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }

        [Route("halls")]
        public async Task<IActionResult> GetHalls()
        {
            var hallViewModel = await Context.Halls
                .ProjectTo<HallViewModel>(Mapper.ConfigurationProvider)
                .ToListAsync();

            return View("HallType", hallViewModel);
        }
    }
}
