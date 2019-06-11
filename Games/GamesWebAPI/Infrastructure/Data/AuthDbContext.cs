using Microsoft.AspNet.Identity.EntityFramework;

namespace GamesWebAPI.Infrastructure.Data
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthDbContext()
            : base("AuthDbContext")
        {

        }
    }
}