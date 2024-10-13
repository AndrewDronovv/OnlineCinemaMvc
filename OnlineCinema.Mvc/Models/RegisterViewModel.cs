using AutoMapper;
using OnlineCinema.Domain.Entities;

namespace OnlineCinema.Mvc.Models
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class RegisterViewModel
    {
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsMan { get; set; }
    }
}
