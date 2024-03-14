using Microsoft.AspNetCore.Identity;

namespace webapi.model
{
    public class AppUser : IdentityUser
    {

        public List<Portfolio> portfolios { get; set; } = new List<Portfolio>();

    }
}
