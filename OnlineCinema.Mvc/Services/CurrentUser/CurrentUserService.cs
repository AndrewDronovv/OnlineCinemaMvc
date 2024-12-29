﻿using OnlineCinema.Domain;
using OnlineCinema.Domain.Common;
using System.Security.Claims;

namespace OnlineCinema.Mvc.Services.CurrentUser;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, AppDbContext context)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
    }

    public int? UserId
    {
        get
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;
            return userId == null ? null : int.Parse(userId);
        }
    }

    public string? Name
    {
        get
        {
            if (UserId == null)
            {
                return null;
            }
            var name = _context.Users.First(u => u.Id == UserId.Value).Name;
            return name;
        }
    }

    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    public IReadOnlyList<string> Roles => _httpContextAccessor.HttpContext?.User?
        .FindAll(ClaimTypes.Role)
        ?.Select(r => r.Value)
        ?.ToList();

    public bool IsAdmin => IsAuthenticated && (Roles?.Any(r => r.ToLower() == StaticRoleNames.ADMIN.ToLower()) ?? false);
}
