using OnlineCinema.Domain.Entities;

namespace OnlineCinema.Mvc.Models
{
    public class HomeViewModel
    {
        public IEnumerable<string> Advertisings { get; set; }
        public IEnumerable<PosterViewModel> Posters { get; set; }
        public IEnumerable<Promotion> Promotions { get; set; }
    }
}
