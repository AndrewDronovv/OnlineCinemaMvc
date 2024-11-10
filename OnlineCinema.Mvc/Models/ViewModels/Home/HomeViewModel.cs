namespace OnlineCinema.Mvc.Models.ViewModels.Home;

public class HomeViewModel
{
    public IEnumerable<string> Advertisings { get; set; }
    public IEnumerable<PosterViewModel> Posters { get; set; }
    public IEnumerable<HomePromotionsViewModel> Promotions { get; set; }
    public IEnumerable<HomeNewsViewModel> News { get; set; }
    public IEnumerable<LoginViewModel> Logins { get; set; }
}
