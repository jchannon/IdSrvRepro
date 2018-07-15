using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Test;

namespace IdSrvRepro
{
  internal static class Users
  {
    public static List<TestUser> Get()
    {
      return new List<TestUser>
      {
        new TestUser{
          SubjectId = "12345",
          Username = "testuser",
          Password = "Password123!",
          Claims = new []
          {
            new Claim(JwtClaimTypes.Name, "General test user")
          }
        }
      };
    }
  }
}
