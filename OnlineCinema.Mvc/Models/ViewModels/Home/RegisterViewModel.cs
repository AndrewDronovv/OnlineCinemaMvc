using System.ComponentModel.DataAnnotations;

namespace OnlineCinema.Mvc.Models.ViewModels.Home
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Необходимо ввести имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо ввести фамилию")]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Необходимо ввести пароль")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Длина {0} должна быть не меньше {2} и максимально {1} символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        [Compare("ConfirmPassword", ErrorMessage = "Пароль не совпадает")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Необходимо ввести повторный пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторный пароль")]
        public string ConfirmPassword { get; set; }
        public bool? IsMan { get; set; }
    }
}