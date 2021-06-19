using AuthorizationMicroservice.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Repository
{
    public class AuthorizeValidation : IAuthorization
    {
        private readonly SymmetricSecurityKey _key;
        private static List<Admin> admins = new List<Admin>()
        {
            new Admin {AdminId = 1,  UserName = "admin@iptm.com", Password = "Awesome123!"}
        };
        public AuthorizeValidation(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }        
        public string CreateToken(string username, string password)
        {
            int adminCount = (from x in admins where x.UserName == username && x.Password == password select x).Count();
            if (adminCount == 0)
            {
                return null;
            }
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, username)                
            };
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = cred
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesc);
            return tokenHandler.WriteToken(token);
        }
    }
}
