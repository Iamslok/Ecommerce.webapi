using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace demo.webapi.demo.Models
{
    public class Helper
    {
        public static string ConnectionString { get; set; }
        private static IConfiguration _configuration;
        public static string SymmetricSecurityKey { get; private set; }

        public static void LoadConfigurations(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = configuration.GetConnectionString("HipaaContext");
            SymmetricSecurityKey = configuration["SecurityConfig:symmetricSecurityKey"];
        }

        //public static string DecryptString(string key, string cipherText)
        //{
        //    byte[] iv = new byte[16];
        //    byte[] buffer = Convert.FromBase64String(cipherText);

        //    using (Aes aes = Aes.Create())
        //    {
        //        aes.Key = Encoding.UTF8.GetBytes(key);
        //        aes.IV = iv;
        //        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        //        using (MemoryStream memoryStream = new MemoryStream(buffer))
        //        {
        //            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
        //            {
        //                using (StreamReader streamReader = new StreamReader(cryptoStream))
        //                {
        //                    return streamReader.ReadToEnd();
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
