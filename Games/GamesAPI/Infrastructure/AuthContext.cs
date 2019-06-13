using Microsoft.AspNet.Identity.EntityFramework;

namespace GamesAPI.Infrastructure
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}