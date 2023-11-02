using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AjooScheme.Domain.Dtos.Account
{
    public class JwtAuthResult
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; }
        [JsonPropertyName("expiredAt")]
        public DateTime ExpirationTime { get; set; }
    }

    public class RefreshToken
    {
        public string UserName { get; set; }
        public string TokenString { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
