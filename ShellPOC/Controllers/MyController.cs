using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ShellPOC.Controllers
{
    public class MyController
    {
        public string CraftJwt()
        {
            //string key = "jwt_signing_secret_key"; //Secret key which will be used later during validation    
            //var issuer = "http://localhost";

            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //var permClaims = new List<Claim>
            //{
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //    new Claim("valid", "1"),
            //    new Claim("userid", "1"),
            //    new Claim("name", "test")
            //};

            //var token = new JwtSecurityToken(issuer,
            //    issuer,
            //    permClaims,
            //    expires: DateTime.Now.AddDays(1),
            //    signingCredentials: credentials);
            //return new JwtSecurityTokenHandler().WriteToken(token);
            string userName = "abc";
            string userId = "226e0054-9d4f-4848-9509-42db8f68b1b1";
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            List<string> userRoles = new List<string>();
            userRoles.Add("Systems");
            userRoles.Add("CanDeleteAllPricingRequestComments");
            foreach(var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            string secret = "StrONGKAutHENTICATIONKEy";//JWT.Secet from appsettings
            string validAudience = "http://localhost:4200";//JWT.validAudience from appsettings
            string validIssuer = "http://localhost:44334";//JWT.validIssuer from appsettings
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var token = new JwtSecurityToken(
                issuer: validIssuer,
                audience: validAudience,
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
