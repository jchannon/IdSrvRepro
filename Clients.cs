using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdSrvRepro
{
  internal class Clients
  {
    public static IEnumerable<Client> Get()
    {
      return new List<Client>
      {
        new Client
        {
          ClientId = "2j8bkfspcj0umv627o8tnvlqfp",
          AllowedGrantTypes = {GrantType.ResourceOwnerPassword},
          AllowOfflineAccess = true,
          AccessTokenLifetime = 1, // Keep these short so that we can easily test refeshing these
          AllowedScopes =
          {
            "myapi/fullaccess",
            IdentityServerConstants.StandardScopes.OfflineAccess
          },
          RequireClientSecret = false
        },
        new Client
        {
          ClientId = "Short Refresh Token Lifetime",
          AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
          AllowOfflineAccess = true,
          AbsoluteRefreshTokenLifetime = 1, // Refresh Tokens for this client will expire after 1 second
          AllowedScopes =
          {
            "myapi/fullaccess",
            IdentityServerConstants.StandardScopes.OfflineAccess
          },
          RequireClientSecret = false
        },
        new Client
        {
          ClientId = "Valid Client",
          ClientSecrets =
          {
            new Secret("Correct Secret".Sha256())
          },
          AllowedGrantTypes = GrantTypes.ClientCredentials,
          AllowedScopes =
          {
            "myapi/fullaccess"
          }
        },


        new Client
        {
          ClientSecrets =
          {
            new Secret("Correct Secret".Sha256())
          },
          //AllowedGrantTypes = GrantTypes.ClientCredentials,


          ClientId = "native.code",
          ClientName = "Native Client (Code with PKCE)",

          RedirectUris = {"http://127.0.0.1"},
          PostLogoutRedirectUris = {"http://127.0.0.1"},

          RequireClientSecret = false,

          //AllowedGrantTypes = GrantTypes.Code,
          AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
          RequirePkce = true,
          AllowedScopes = {"openid", "profile", "email", "api", "myapi/fullaccess"},

          AllowOfflineAccess = true,
          RefreshTokenUsage = TokenUsage.ReUse
        }
      };
    }
  }
}
