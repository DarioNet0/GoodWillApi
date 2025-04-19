namespace GoodWill.Domain.Security.Cryptography
{
    public interface IPasswordEncrypter
    {
        string Encrypt(string password);
        bool verify(string password, string passwordHash);   
    }
}
