using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MSFSAddonsHub.Dal.BL;
using MSFSAddonsHub.Dal.Models;

namespace MSFSAddonsHub.WebApi.Services {
    public interface IUserService {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        bool RevokeToken(string token, string ipAddress);
 
    }


    public class UserService : IUserService {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications

        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly AppSettings _appSettings;
        private List<User> _users = new List<User>();
        
        public UserService(IOptions<AppSettings> appSettings, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
            

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
        public   AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress) {
            //var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            var user = _userManager.Users.Where(w=>w.UserName ==model.Username ).FirstOrDefault();

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result =  _signInManager.PasswordSignInAsync(model.Username, model.Password, true, lockoutOnFailure: false);

            User users = new User();
            users.Username = model.Username;
            users.Password = model.Password;
          
            if (result.Result.Succeeded)
            {
                // return null if user not found
                if (user == null)
                    return null;
            }

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = generateJwtToken(users);
          //  var refreshToken = generateRefreshToken(ipAddress);

            // save refresh token
            //user.RefreshTokens.Add(refreshToken);

            return new AuthenticateResponse(users, jwtToken, null);

        }


        public IdentityUser GetById(string id) {
            return _userManager.Users.Where(w=>w.Id==id).FirstOrDefault();
        }
        public IEnumerable<IdentityUser> GetAll() {
            return (IEnumerable<IdentityUser>)_userManager.Users;
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