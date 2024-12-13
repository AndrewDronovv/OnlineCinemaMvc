using OnlineCinema.Domain.Entities;
using OnlineCinema.Mvc.Models.ViewModels.Hall;

namespace OnlineCinema.Mvc.Models.ViewModels.Movies;

public class MovieWithSessionsViewModel
{
    public Movie Movie { get; set; }
    public IEnumerable<Session> Sessions { get; set; }
    public IEnumerable<HallViewModel> Halls { get; set; }
}
