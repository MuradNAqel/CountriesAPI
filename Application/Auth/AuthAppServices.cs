using ApplicationContract.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
    public class AuthAppServices : IAuthAppServiece
    {
        private readonly UserManager<IdentityUser> _userManager;
        IdentityUser _user;
        public AuthAppServices(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            _user = await _userManager.FindByIdAsync(userId);
            if (_user == null)
            {
                throw new Exception("User not found");
            }
            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ConfirmEmailAsync(_user, normalToken);

            if (result.Succeeded)
                return "Email confirmed successfully!";


            throw new Exception("Email did not confirm");
        }

        public string CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.Now.AddHours(5),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        private List<Claim> GetClaims()
        {
            var claims = new List<Claim> { new Claim("email", _user.Email)};
            claims.Add(new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()));
            claims.Add(new Claim("role", "admin"));
            claims.Add(new Claim("name", _user.UserName));
            return claims;

        }

        private SigningCredentials GetSigningCredentials()
        {
            var signingKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("=SFTxZ3O$[/wbxjDl0>DK>Qm\\o&[96818/a1&l{5BGn,0?1q$_"));
            return new SigningCredentials(signingKey,SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> EmailIsExist(string userEmail)
        {
            _user = await _userManager.FindByEmailAsync(userEmail);
            return (_user != null);
        }

        public async Task<bool> ValidateUser(string userEmail, string userPassword)
        {
            _user = await _userManager.FindByEmailAsync(userEmail);

            return (_user != null && await _userManager.CheckPasswordAsync(_user,userPassword));
        }
    }
}
