using System;
using System.Xml.Linq;
using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Newtonsoft.Json.Linq;

namespace JWTDemo.Utils
{
    public static class JWTAuth
    {
        public static string GenerateToken(Dictionary<string, object> payload, string secret)
        {
            IJwtAlgorithm algorithm = new RS256Algorithm(certisecretficate);
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            return encoder.Encode(payload);
        }

        public static bool ValidateToken(string accessToken, int userId)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new RS256Algorithm(certificate);
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                var json = decoder.Decode(accessToken);
                Console.WriteLine(json);
            }
            catch (TokenNotYetValidException)
            {
                Console.WriteLine("Token is not valid yet");
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
            }
        }
    }
}

