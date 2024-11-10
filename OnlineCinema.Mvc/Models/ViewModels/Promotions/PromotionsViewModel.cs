using OnlineCinema.Domain.Entities;

namespace OnlineCinema.Mvc.Models.ViewModels.Promotions;

public class PromotionsViewModel
{
    public IEnumerable<Promotion> Promotions { get; set; }
}
