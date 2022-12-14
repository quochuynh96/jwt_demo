using System.Security.Cryptography;
using System.Text;

namespace JWTDemo.Utils;

public class Aes
{
    private static RijndaelManaged rijndael = new RijndaelManaged();
    private static System.Text.UnicodeEncoding unicodeEncoding = new UnicodeEncoding();

    private const int CHUNK_SIZE = 128;

    private void InitializeRijndael()
    {
        rijndael.Mode = CipherMode.CBC;
        rijndael.Padding = PaddingMode.PKCS7;            
    }

    public Aes()
    {
        InitializeRijndael();
            
        rijndael.KeySize = CHUNK_SIZE;
        rijndael.BlockSize = CHUNK_SIZE;

        rijndael.GenerateKey();
        rijndael.GenerateIV();
    }

    public Aes(String base64key, String base64iv)
    {
        InitializeRijndael();

        rijndael.Key = Convert.FromBase64String(base64key);
        rijndael.IV = Convert.FromBase64String(base64iv);    
    }

    public Aes(byte[] key, byte[] iv)
    {
        InitializeRijndael();

        rijndael.Key = key;
        rijndael.IV = iv;
    }

    public string Decrypt(byte[] cipher)
    {
        ICryptoTransform transform = rijndael.CreateDecryptor();            
        byte[] decryptedValue = transform.TransformFinalBlock(cipher, 0, cipher.Length);
        return unicodeEncoding.GetString(decryptedValue);
    }

    public string DecryptFromBase64String(string base64cipher)
    {
        return Decrypt(Convert.FromBase64String(base64cipher));
    }
              
    public byte[] EncryptToByte(string plain)
    {
        ICryptoTransform encryptor = rijndael.CreateEncryptor();
        byte[] cipher = unicodeEncoding.GetBytes(plain);
        byte[] encryptedValue = encryptor.TransformFinalBlock(cipher, 0, cipher.Length);
        return encryptedValue;
    }

    public string EncryptToBase64String(string plain)
    {
        return Convert.ToBase64String(EncryptToByte(plain));
    }
}