using OnlineCinema.Domain.Common;

namespace OnlineCinema.Domain.Entities;

public class Hall : Entity
{
    public string Name { get; set; }
    public string PicturePath { get; set; }
    public string Description { get; set; }
}