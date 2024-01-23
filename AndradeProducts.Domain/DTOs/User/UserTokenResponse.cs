using System.Collections.Generic;

namespace AndradeProducts.Domain.DTOs.User
{
    public class UserTokenResponse
    {
        public IEnumerable<UserClaimsResponse> Claims { get; set; }
    }
}
