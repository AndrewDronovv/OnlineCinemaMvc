using OnlineCinema.Domain.Entities;

namespace OnlineCinema.Mvc.Models.ViewModels.Movies;

public class MoviesViewModel
{
    public IEnumerable<Movie> Movies { get; set; }
}
