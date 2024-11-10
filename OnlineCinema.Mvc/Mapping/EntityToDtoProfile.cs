using AutoMapper;
using OnlineCinema.Domain.Entities;
using OnlineCinema.Mvc.Models.ViewModels.Home;

namespace OnlineCinema.Mvc.Mapping;

public class EntityToDtoProfile : Profile
{
    public EntityToDtoProfile()
    {
        CreateMap<User, RegisterViewModel>();
    }
}
