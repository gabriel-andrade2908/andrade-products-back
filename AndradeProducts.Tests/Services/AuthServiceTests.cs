using AndradeProducts.Domain.DTOs.Product;
using AndradeProducts.Domain.DTOs.User;
using AndradeProducts.Domain.Entities;
using AndradeProducts.Domain.Helpers.JWTSettings;
using AndradeProducts.Domain.Settings.ErrorHandler.ErrorStatusCodes;
using AndradeProducts.Domain.v1.Interfaces.Builders;
using AndradeProducts.Domain.v1.Interfaces.Repositories;
using AndradeProducts.Domain.v1.Interfaces.Services;
using AndradeProducts.Domain.v1.Services;
using Castle.DynamicProxy.Generators;
using Logistics.Domain.Services;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AndradeProducts.Tests.Services
{
    public class AuthServiceTests
    {
        private readonly IAuthService _authService;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<ILoginResponseBuilder> _builderRepository;
        private readonly Mock<IOptions<JwtSettings>> _jwtSettings;
        const string userName = "userName";
        const string password = "password";

        public AuthServiceTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _builderRepository = new Mock<ILoginResponseBuilder>();
            _jwtSettings = new Mock<IOptions<JwtSettings>>();
            _jwtSettings.Setup(x => x.Value).Returns(new JwtSettings
            {
                Audience = "Audience",
                DurationInMinutes = 2,
                Issuer = "Issuer",
                Key = "1105D15CB0D48F542342DA6828BF153DE"
            });
            _authService = new AuthService(_jwtSettings.Object, _userRepository.Object, 
                _builderRepository.Object);
        }

        [Fact]
        public async Task ValidateLoginAsync_IdFound_ReturnProduct()
        {
            var user = new User("Gabriel", userName, password);
            var token = "token";

            _builderRepository.Setup(x => x.BuildAccessToken(token)).Returns(token);
            _builderRepository.Setup(x => x.BuildUserToken(new List<Claim>())).Returns(new UserTokenResponse());
            _userRepository.Setup(x => x.ValidateLoginAsync(userName, password)).ReturnsAsync(user);

            LoginResponse result = await _authService.LoginAsync(userName, password);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ValidateLoginAsync_IdNotFound_ReturnNotFoundException()
        {
            NotFoundException exception = await Assert.ThrowsAsync<NotFoundException>(() => _authService
            .LoginAsync(userName, password));

            Assert.Equal("User or password are invalids", exception.Errors[0]);
        }
    }
}
