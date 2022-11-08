using System;
using System.Xml.Linq;
using JWT;

namespace JWTDemo.Utils
{
    public static class JWTAuth
    {
        public static string GenerateToken(Dictionary<string, object> payload, string secret)
        {
            return JWT.JsonWebToken.Encode(payload, secret, JWT.JwtHashAlgorithm.HS256);
        }

        public static bool ValidateToken(string accessToken, int userId)
        {
            try
            {
                var payload = JWT.JsonWebToken.Decode(accessToken, secret);
                dynamic obj = JObject.Parse(payload);
                TimeSpan ts = DateTime.UtcNow - DateTime.Parse(obj.expires.ToString());

                if (obj.user_id == userId && ts.Days < 1)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

