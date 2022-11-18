using System;
using System.Text.Json.Serialization;

namespace JWTDemo.Models
{
	public class RefreshTokenModel
	{
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; }

        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }
}

