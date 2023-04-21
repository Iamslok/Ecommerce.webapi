using demo.webapi.demo.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace demo.webapi.demo.Repos
{
    public class Authentication:IAuthentication
    {
        public async Task<TokenModel> GenerateJwtToken(string userName, int userid)
        {
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("4e9f5a0824554525bbf35490d8da48f2"));
            SigningCredentials signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, userName),
                            new Claim(ClaimTypes.PrimarySid,userid.ToString())
                          };

            DateTime tokenExpiresIn = DateTime.UtcNow.AddDays(2);

            JwtSecurityToken tokenOptions = new JwtSecurityToken(
                    claims: claims,
                    expires: tokenExpiresIn,
                    signingCredentials: signinCredentials
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            await Task.CompletedTask;
            return (new TokenModel { Token = tokenString, DateExpires = tokenExpiresIn });

        }
    }
}
