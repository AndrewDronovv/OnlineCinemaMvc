﻿using AutoMapper;
using OnlineCinema.Domain.Entities;
using OnlineCinema.Mvc.Models.ViewModels.Home;

namespace OnlineCinema.Mvc.Mapping;

public class DtoToEntityProfile : Profile
{
    public DtoToEntityProfile()
    {
        CreateMap<RegisterViewModel, User>();
    }
}