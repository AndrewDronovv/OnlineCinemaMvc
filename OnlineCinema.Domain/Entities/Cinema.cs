using OnlineCinema.Domain.Common;

namespace OnlineCinema.Domain.Entities;

public class Cinema : Entity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Station { get; set; }
    public string PicturePath { get; set; }
    public ICollection<Hall> Halls { get; set; }
}
