using OnlineCinema.Domain.Common;

namespace OnlineCinema.Domain.Entities;

public class News : Entity
{
    public string ImagePath { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}
