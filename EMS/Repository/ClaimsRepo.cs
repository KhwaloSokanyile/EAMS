using EMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace EMS.Repository
{
    public class ClaimsRepo: UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ClaimsRepo(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            :base(userManager, roleManager,options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FirstName", user.Name ?? ""));
            identity.AddClaim(new Claim("LastName", user.Surname ?? ""));
            return identity;
        }
    }
}
