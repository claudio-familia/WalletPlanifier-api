using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Common.Services.Contracts;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IDataRepository<User> _userRepository;        
        private readonly IConfiguration configuration;
        private readonly ICryptographyService _cryptographyService;
        public AuthService(IDataRepository<User> baseRepository,                           
                           IConfiguration _configuration,
                           ICryptographyService cryptographyService)
        {
            _userRepository = baseRepository;
            configuration = _configuration;
            _cryptographyService = cryptographyService;            
        }

        private string Encrypt(string text)
        {
            return _cryptographyService.Encrypt(text, configuration["Authentication:SecretKey"]);
        }

        public User Login(string username, string password)
        {
            if (_userRepository.Exists(user => user.UserName == username))
            {
                string passwordEncrypt = Encrypt(password);

                return _userRepository.Get(user => user.UserName == username && user.Password == passwordEncrypt);
            }

            return null;
        }

        public string GenerateJWT(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Name, user.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expires = DateTime.Now.AddYears(2);

            var token = new JwtSecurityToken(
                issuer: configuration["Authentication:Issuer"],
                audience: configuration["Authentication:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }      
}
