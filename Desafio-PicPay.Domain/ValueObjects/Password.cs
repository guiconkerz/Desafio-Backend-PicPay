using Desafio_PicPay.Shared.Exceptions;
using Desafio_PicPay.Shared.ValueObjects;

namespace Desafio_PicPay.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        public string Hash { get; private set; }

        public Password(string hash)
        {
            Hash = hash.Trim();
        }

        public bool Verify(string password)
        {
            InvalidParametersException.ThrowIfNull(password, "Invalid Password");
            return BCrypt.Net.BCrypt.Verify(password.Trim(), Hash);
        }

        public void Encrypt(string password)
        {
            InvalidParametersException.ThrowIfNull(password, "No password was provided.");
            BCrypt.Net.BCrypt.HashPassword(Hash);
        }

        public void Encrypt()
        {
            InvalidParametersException.ThrowIfNull(Hash, "No password was provided.");
            BCrypt.Net.BCrypt.HashPassword(Hash);
        }

        public void Update(string password)
        {
            InvalidParametersException.ThrowIfNull(password, "Invalid Password");
            Encrypt(password.Trim());
            Hash = password;
        }
    }
}
