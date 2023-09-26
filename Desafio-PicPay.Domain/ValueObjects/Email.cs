using Desafio_PicPay.Shared.ValueObjects;

namespace Desafio_PicPay.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; } = string.Empty;
        protected Email() { }

        public Email(string address)
        {
            Address = address.Trim();
        }

        public static implicit operator string(Email email) => email.ToString();
        public override string ToString() => Address.Trim();
        public static implicit operator Email(string address) => new Email(address);

    }
}
