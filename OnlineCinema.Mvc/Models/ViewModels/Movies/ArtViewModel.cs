using OnlineCinema.Domain.Entities;

namespace OnlineCinema.Mvc.Models.ViewModels.Movies
{
    public class ArtViewModel
    {
        public int Id { get; set; }
        public string CardImagePath { get; set; }
        public int AgeRating { get; set; }
        public string Name { get; set; }
        public ICollection<MovieGenre> Genres { get; set; }
    }
}
