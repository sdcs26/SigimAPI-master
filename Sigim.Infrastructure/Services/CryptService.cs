using Sigim.Application.Contracts.Infrastructure;
using System.Text;

namespace Sigim.Infrastructure.Services
{
    public class CryptService : ICryptService
    {
        public string EncryptPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(10);

            string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hash;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        public string ConvertBase64(string text)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(text));
        }
        public string DecryptBase64(string base64)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(base64));
        }
    }
}
