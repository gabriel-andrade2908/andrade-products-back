using AndradeProducts.Domain.DTOs.User;
using System.Collections.Generic;
using System.Security.Claims;

namespace AndradeProducts.Domain.v1.Interfaces.Builders
{
    public interface ILoginResponseBuilder
    {
        string BuildAccessToken(string accessToken);
        UserTokenResponse BuildUserToken(IEnumerable<Claim> claims);
    }
}
