using Desafio_PicPay.Shared.Enums;

using Desafio_PicPay.Shared.Entities;

namespace Desafio_PicPay.Domain.Entities
{
    public class UserType : Entity
    {
        protected UserType() { }
        public int UserTypeId { get; private set; }
        public TypesUser Type { get; private set; }
    }
}
