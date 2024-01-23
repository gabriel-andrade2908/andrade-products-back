namespace AndradeProducts.Domain.DTOs.User
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public UserTokenResponse UserToken { get; set; }
    }
}
