using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MSFSClubManager.Dal.BL;
using MSFSClubManager.Dal.Models;

namespace MSFSClubManager.WebApi.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        bool RevokeToken(string token, string ipAddress);

    }


    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private IConfiguration _configRoot;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<RegisterModel> _logger;

        private readonly AppSettings _appSettings;
        private List<User> _users = new List<User>();

        public UserService(IConfiguration configRoot, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<RegisterModel> logger)
        {
            _configRoot = (IConfigurationRoot)configRoot;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;


        }
        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
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



        public  string  GetUserAsync(User model)
        {
            // Resolve the user via their email
            var user = Task.Run(() => _userManager.FindByEmailAsync(model.Username)).Result;
            // Get the roles for the user
            var uroles = Task.Run(() => _userManager.GetRolesAsync(user)).Result;
            return  String.Join(",", uroles);           
        }

            private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configRoot.GetValue<string>("JWTSecret");

            
            _logger.Log(LogLevel.Information, $"JWT Secret from Everleap={secret}");

            string roles =  GetUserAsync(user);
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {


            Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim("CreatedBy", user.FirstName.Substring(0,1).ToUpper() + ""  + user.LastName.Substring(0,1).ToUpper()),
                    new Claim(ClaimTypes.Email, user.Username),
                    new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                     new Claim(ClaimTypes.Role,roles)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken generateRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };
            }
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
        {
            //var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            var user = _userManager.Users.Where(w => w.UserName == model.Username).FirstOrDefault();

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = _signInManager.PasswordSignInAsync(model.Username, model.Password, true, lockoutOnFailure: false);

            User users = new User();
            users.Username = model.Username;
            users.Password = model.Password;
            users.FirstName = user.FirstName;
            users.LastName = user.LastName;


            if (result.Result.Succeeded)
            {
                // return null if user not found
                if (user == null)
                    return null;
            }

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = generateJwtToken(users);
            var refreshToken = generateRefreshToken(ipAddress);

            // save refresh token
           // users.RefreshTokens.Add(refreshToken);

            return new AuthenticateResponse(users, jwtToken, null);

        }


        public IdentityUser GetById(string id)
        {
            return _userManager.Users.Where(w => w.Id == id).FirstOrDefault();
        }
        public IEnumerable<IdentityUser> GetAll()
        {
            return (IEnumerable<IdentityUser>)_userManager.Users;
        }

        public bool RevokeToken(string token, string ipAddress)
        {
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