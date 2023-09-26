using Desafio_PicPay.Domain.ValueObjects;
using Desafio_PicPay.Shared.Entities;
using Desafio_PicPay.Shared.Enums;

namespace Desafio_PicPay.Domain.Entities
{
    public class User : Entity
    {
        protected User() { }
        public User(string name, Email email, Password password, DocumentType documentType, UserType userType)
        {
            Name = name;
            Email = email;
            Password = password;
            DocumentType = documentType;
            UserType = userType;
        }

        public int UserId { get; private set; }
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public DocumentType DocumentType { get; private set; }
        public int FkUserType { get; private set; }
        public UserType UserType { get; private set; }
    }
}
