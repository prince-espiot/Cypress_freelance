using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DemoWebApp.Data;

namespace DemoWebApp.Api
{
    public class IdentityProvider
    {
        private readonly PseudoDbContext _pseudoDbContext;

        public IdentityProvider(PseudoDbContext pseudoDbContext)
        {
            _pseudoDbContext = pseudoDbContext;
        }

        public ClaimsPrincipal? Authenticate(AppUserCredentials appUserCredentials, string authenticationScheme)
        {
            var user = _pseudoDbContext.Users.Where(x =>
                x.Username == appUserCredentials.Username
                && x.PasswordHash == appUserCredentials.PasswordHash
                && !x.IsLocked)
                .FirstOrDefault();
            if (user == null)
                return null;

            var identity = new ClaimsIdentity(authenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Username));

            return new ClaimsPrincipal(identity);
        }
    }
}
