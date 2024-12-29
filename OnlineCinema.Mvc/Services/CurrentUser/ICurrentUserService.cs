namespace OnlineCinema.Mvc.Services.CurrentUser;

public interface ICurrentUserService
{
    int? UserId { get; }
    string? Name { get; }
    bool IsAuthenticated { get; } 
    bool IsAdmin { get; } 
    IReadOnlyList<string> Roles { get; }
}
