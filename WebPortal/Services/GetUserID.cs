using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace WebPortal.Services
{
    public class GetUserID:IGetUserID
    {
        private readonly IHttpContextAccessor _httpContext;

        public GetUserID( IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string UserID()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
