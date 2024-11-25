namespace OnlineCinema.Mvc.Models.ViewModels.Home;

public class HomePromotionViewModel
{
    public int Id { get; set; }
    public string ImagePath { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string ButtonText { get; set; }
    public string? Link { get; set; }
}
