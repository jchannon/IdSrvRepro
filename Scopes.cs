using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdSrvRepro
{
  internal class Scopes
  {
    public static IEnumerable<IdentityResource> GetIdentityScopes()
    {
      return new IdentityResource[]
      {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResources.Email(),
      };
    }

    public static IEnumerable<ApiResource> GetApiScopes()
    {
      return new List<ApiResource>
      {
        new ApiResource("myapi", "The Api")
        {
          Scopes = {new Scope("myapi/fullaccess")}
        },
        new ApiResource("api", "Demo API")
        {
          ApiSecrets = {new Secret("secret".Sha256())}
        }
      };
    }
  }
}
