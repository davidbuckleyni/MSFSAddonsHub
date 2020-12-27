 
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MSFSAddonsHub.Dal.Models
{
    public class User
    {

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int? UserType { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}