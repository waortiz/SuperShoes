namespace SuperShoes.Api.Filters
{
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Threading;
    using System.Threading.Tasks;

    public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
    {
        protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested(); // Unfortunately, UserManager doesn't support CancellationTokens.
            if (!(userName.Equals("my_user", System.StringComparison.InvariantCultureIgnoreCase) && password == "my_password"))
            {
                return null;
            }

            // Create a ClaimsIdentity with all the claims for this user.
            cancellationToken.ThrowIfCancellationRequested();
            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(userName));
            return new ClaimsPrincipal(identity);
        }
    }
}