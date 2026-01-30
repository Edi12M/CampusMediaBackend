using System.Security.Claims;
using Microsoft.AspNetCore.Http;
namespace CampusMediaBack.Services;

public interface ICurrentUserService
{
    int? GetCurrentUserId();
}

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public int? GetCurrentUserId()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        var claim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return claim != null && int.TryParse(claim, out var id) ? id : (int?)null;
    }
}

