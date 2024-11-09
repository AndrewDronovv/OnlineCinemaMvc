using AutoMapper;
using OnlineCinema.Domain.Entities;
using OnlineCinema.Mvc.Models;

namespace OnlineCinema.Mvc.Mapping;

public class DtoToEntityProfile : Profile
{
    public DtoToEntityProfile()
    {
        CreateMap<RegisterViewModel, User>();
    }
}
