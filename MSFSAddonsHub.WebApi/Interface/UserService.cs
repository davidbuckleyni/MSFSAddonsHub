using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
 
 
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MSFSAddonsHub.Dal.BL;
using MSFSAddonsHub.Dal.Models;

namespace MSFSAddonsHub.WebApi.Services {
    public interface IUserService {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        bool RevokeToken(string token, string ipAddress);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }


    public class UserService : IUserService {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id=1, Username="David",Password="Test12345" }
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings) {
            _appSettings = appSettings.Value;
        }
        public AuthenticateResponse RefreshToken(string token, string ipAddress) {
            var user = _users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            // return null if no user found with token
            if (user == null) return null;

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            // return null if token is no longer active
            if (!refreshToken.IsActive) return null;

            // replace old refresh token with a new one and save
            var newRefreshToken = generateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            user.RefreshTokens.Add(newRefreshToken);


            // generate new jwt
            var jwtToken = generateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
        }


        private string generateJwtToken(User user) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken generateRefreshToken(string ipAddress) {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider()) {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };
            }
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress) {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = generateJwtToken(user);
          //  var refreshToken = generateRefreshToken(ipAddress);

            // save refresh token
            //user.RefreshTokens.Add(refreshToken);

            return new AuthenticateResponse(user, jwtToken, null);

        }


        public User GetById(int id) {
            return _users.Where(w=>w.Id==id).FirstOrDefault();
        }
        public IEnumerable<User> GetAll() {
            return _users;
        }

        public bool RevokeToken(string token, string ipAddress) {
            var user = _users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            // return false if no user found with token
            if (user == null) return false;

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            // return false if token is not active
            if (!refreshToken.IsActive) return false;

            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            

            return true;
        }

       

      
    }
}