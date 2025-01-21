using OnlineCinema.Mvc.Models.Dto.Common;

namespace OnlineCinema.Mvc.Models.Dto.Promotions;

public class PromotionDto : EntityDto
{
    public DateTime DateTime { get; set; }
    public string ImagePath { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string ButtonText { get; set; }
    public string? Link { get; set; }
}
