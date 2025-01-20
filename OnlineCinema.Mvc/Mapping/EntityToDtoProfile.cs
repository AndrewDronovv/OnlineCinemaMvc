﻿using AutoMapper;
using OnlineCinema.Domain.Entities;
using OnlineCinema.Mvc.Models.Dto.Genres;
using OnlineCinema.Mvc.Models.ViewModels.Account;
using OnlineCinema.Mvc.Models.ViewModels.Hall;
using OnlineCinema.Mvc.Models.ViewModels.Home;
using OnlineCinema.Mvc.Models.ViewModels.Movies;
using OnlineCinema.Mvc.Models.ViewModels.News;
using OnlineCinema.Mvc.Models.ViewModels.Promotions;

namespace OnlineCinema.Mvc.Mapping;

public class EntityToDtoProfile : Profile
{
    public EntityToDtoProfile()
    {
        CreateMap<User, RegisterViewModel>();
        CreateMap<Promotion, PromotionViewModel>();
        CreateMap<Movie, ArtViewModel>();
        CreateMap<Movie, KidsViewModel>();
        CreateMap<Movie, MovieViewModel>();
        CreateMap<Movie, HomePosterViewModel>();
        CreateMap<Promotion, HomePromotionViewModel>();
        CreateMap<News, HomeNewsViewModel>();
        CreateMap<News, NewsViewModel>();
        CreateMap<Promotion, PromotionViewModel>();
        CreateMap<Hall, HallViewModel>();
        CreateMap<Genre, GenreDto>();
        CreateMap<User, AccountViewModel>();    
    }
}
