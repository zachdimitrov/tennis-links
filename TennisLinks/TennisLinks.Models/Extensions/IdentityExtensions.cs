using System.Security.Claims;
using System.Security.Principal;

namespace TennisLinks.Models.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetDetailsId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("DetailsId");
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
