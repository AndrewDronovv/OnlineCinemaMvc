using OnlineCinema.Domain.Enums;

namespace OnlineCinema.Mvc.Models.ViewModels.Hall;

public class HallViewModel
{
    public string Name { get; set; }
    public HallType HallType { get; set; }
    public string PicturePath { get; set; }
    public string Description { get; set; }
}
