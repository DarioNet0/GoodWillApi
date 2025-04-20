using GoodWill.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace GoodWill.Infrastructure.Security.Cryptography
{
    public class BCryptography : IPasswordEncrypter
    {
        public string Encrypt(string password)
        {
            string passwordHash = BC.HashPassword(password);

            return passwordHash;
        }
        public bool verify(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
