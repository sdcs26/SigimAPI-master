namespace Sigim.Application.Contracts.Infrastructure
{
    public interface ICryptService
    {
        public string EncryptPassword(string password);
        public bool VerifyPassword(string password, string hashedPassword);
        public string ConvertBase64(string text);
        public string DecryptBase64(string base64);
    }
}
