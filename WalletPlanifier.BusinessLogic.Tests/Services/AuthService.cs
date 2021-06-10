using System;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using Xunit;
using Moq;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.BusinessLogic
{
    public class AuthService
    {
        private readonly LoginDto _loginUser;
        private readonly User _user;
        private readonly Mock<IAuthService> _authService;
        public AuthService()
        {
            _loginUser = new LoginDto()
            {
                UserName = "String",
                Password = "String"
            };

            _user = new User()
            {
                BirthDate = DateTime.Now,
                CreationTime = DateTime.Now,
                LastModificationTime = DateTime.Now,
                DeletionTime = DateTime.Now,
                CreatorUserId = 0,
                LastModifierUserId = 0,
                DeleterUserId = 0,
                Email = "string@string.com",
                FirstName = "String",
                Gender = "M",
                Id = 1,
                IsDeleted = false,
                LastName = "String",
                Nationality = "String",
                Password = "String",
                Profession = "String",
                UserName = "String",
            };

            _authService = new Mock<IAuthService>();

            _authService.Setup(service => service.GenerateJWT(It.IsAny<User>())).Returns("Some Generated JWT");
        }

        [Fact]
        public void ShouldReturnUserObjectWithValidatedUser()
        {
            _authService.Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(_user);

            var user = _authService.Object.Login(_loginUser.UserName, _loginUser.Password);

            _authService.Verify(x => x.Login(_loginUser.UserName, _loginUser.Password), Times.Once);

            Assert.Equal(user, _user);
        }

        [Fact]
        public void ShouldReturnNullObjectWithInValidatedUser()
        {
            _authService.Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(new User());

            var user = _authService.Object.Login(_loginUser.UserName, _loginUser.Password);

            _authService.Verify(x => x.Login(_loginUser.UserName, _loginUser.Password), Times.Once);

            Assert.NotEqual(user, _user);
            Assert.NotSame(user, _user);
        }

        [Fact]
        public void ShouldReturnJWTTokenWithValidatedUser()
        {
            var jwtToken = _authService.Object.GenerateJWT(_user);

            Assert.True(jwtToken.Length > 0);
        }
    }
}
