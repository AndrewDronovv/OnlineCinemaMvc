using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Domain;

namespace OnlineCinema.Mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected IMapper Mapper { get; set; }
        protected AppDbContext Context { get; set; }

        protected BaseApiController(IMapper mapper, AppDbContext context)
        {
            Mapper = mapper;
            Context = context;
        }
    }
}
