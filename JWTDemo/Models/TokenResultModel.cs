using System;
using System.Text.Json.Serialization;

namespace JWTDemo.Models.Response
{
	public class TokenResultModel
	{
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public RefreshTokenModel RefreshToken { get; set; }
	}
}

