using OnlineCinema.Domain.Common;

namespace OnlineCinema.Domain.Entities;

public class Promotion : Entity
{
    public DateTime DateTime { get; set; }
    public string ImagePath { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string ButtonText { get; set; }
    public string? Link { get; set; }
}