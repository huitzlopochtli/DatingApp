using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DatingApp.Api.DTOs;
using DatingApp.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.Api.Security
{
    public class Security
    {

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computerHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computerHash.Length; i++)
                    if (computerHash[i] != passwordHash[i])
                        return false;
            }

            return true;
        }

        public static Object GenerateLoginToken(User userFromRepo, IConfiguration _config)
        {
            //Add the users credentials to a claims list
            var claimes = new[]{
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            //Specify the key from app settings
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            //Specify the Security Algorithm
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            //Token Descriptor that is going to pass to JWT
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimes),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            //JWT Initialise
            var tokenHandlr = new JwtSecurityTokenHandler();

            //Create token
            var token = tokenHandlr.CreateToken(tokenDescriptor);

            return new
            {
                //Write the token
                token = tokenHandlr.WriteToken(token)
            };
        }
    }
}