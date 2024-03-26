using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Datingapp.Data;
using Datingapp.Entities;
using Datingapp.interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace Datingapp.Services
{
        public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            
        }
      public String CreateToken (AppUser user)
        {
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.NameId,user.UserName )

             };
             var creds =new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);
             var tokenDescriptor= new SecurityTokenDescriptor
             {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = creds

             };

             var tokenHandler =  new JwtSecurityTokenHandler();

             var token = tokenHandler.CreateToken(tokenDescriptor);

             return tokenHandler.WriteToken(token);


        }
       

        
    }
}