using OnlineCinema.Domain.Common;

namespace OnlineCinema.Domain.Entities
{
    public class Session : Entity
    {
        public DateTime DateStart { get; set; }
        public int Price { get; set; }
        
        public int MovieId { get; set; }
        public Movie Movie{ get; set; }
        
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
