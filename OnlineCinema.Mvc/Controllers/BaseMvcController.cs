using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Domain;

namespace OnlineCinema.Mvc.Controllers;

public abstract class BaseMvcController : Controller
{
    protected IMapper Mapper { get; set; }
    protected AppDbContext Context { get; set; }

    protected BaseMvcController(IMapper mapper, AppDbContext context)
    {
        Mapper = mapper;
        Context = context;
    }
}
