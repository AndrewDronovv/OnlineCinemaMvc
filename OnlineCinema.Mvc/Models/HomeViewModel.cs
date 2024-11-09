namespace OnlineCinema.Mvc.Models;

public class HomeViewModel
{
    public IEnumerable<string> Advertisings { get; set; }
    public IEnumerable<PosterViewModel> Posters { get; set; }
    public IEnumerable<PromotionViewModel> Promotions { get; set; }
    public IEnumerable<NewsViewModel> News { get; set; }
    public IEnumerable<LoginViewModel> Logins { get; set; }
}
