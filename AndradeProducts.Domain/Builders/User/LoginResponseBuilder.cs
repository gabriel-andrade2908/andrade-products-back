using AndradeProducts.Domain.DTOs.User;
using AndradeProducts.Domain.Entities;
using AndradeProducts.Domain.v1.Interfaces.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AndradeProducts.Domain.Builders.User
{
    public class LoginResponseBuilder : ILoginResponseBuilder
    {
        public string BuildAccessToken(string accessToken)
        {
            return accessToken;
        }

        public UserTokenResponse BuildUserToken(IEnumerable<Claim> claims)
        {
            return new UserTokenResponse
            {
                Claims = claims.Select(c => new UserClaimsResponse { Type = c.Type, Value = c.Value })
            };
        }
    }
}
