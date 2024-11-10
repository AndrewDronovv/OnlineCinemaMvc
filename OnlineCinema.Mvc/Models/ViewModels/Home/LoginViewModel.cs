using System.ComponentModel.DataAnnotations;

namespace OnlineCinema.Mvc.Models.ViewModels.Home;

public class LoginViewModel
{
    [Required(ErrorMessage = "Необходимо ввести email адрес")]
    [EmailAddress]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Необходимо ввести пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string? Phone { get; set; }
    [Display(Name = "Запомнить меня?")]
    public bool RememberMe { get; set; }

    public string? Name { get; set; }
}
