using OnlineCinema.Domain.Common;
using OnlineCinema.Domain.Enums;

namespace OnlineCinema.Domain.Entities;

public class Hall : Entity
{
    public string Name { get; set; }
    public HallType HallType { get; set; }
    public string PicturePath { get; set; }
    
    public int CinemaId { get; set; }
    public Cinema Cinema { get; set; }
}
