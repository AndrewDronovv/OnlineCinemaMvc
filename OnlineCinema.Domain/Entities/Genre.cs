﻿using OnlineCinema.Domain.Common;

namespace OnlineCinema.Domain.Entities;

public class Genre : Entity
{
    public string Name { get; set; }
    public ICollection<MovieGenre> MovieGenres { get; set; }
}
