using OnlineCinema.Domain.Common;

namespace OnlineCinema.Domain.Entities;

public class Movie : Entity
{
    public string Name { get; set; }
    public string OriginalName { get; set; }
    public ICollection<MovieGenre> MovieGenres { get; set; }
    public int Duration { get; set; }
    public int AgeRating { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
    public string Actor { get; set; }
    public string Country { get; set; }
    public DateOnly PremiereDate { get; set; }
    public DateOnly WorldPremiere { get; set; }
    public string PosterPath { get; set; }
    public float Rating { get; set; }
    public bool IsVisible { get; set; }
    public string CardImagePath { get; set; }
}