using Desafio_PicPay.Shared.Entities;

namespace Desafio_PicPay.Domain.Entities
{
    public class Transaction : Entity
    {
        protected Transaction() { }
        public int TransactionId { get; private set; }
        public decimal Value { get; private set; }
        public decimal PreviousValue { get; private set; }
        public decimal NewValue { get; private set; }
        public int FkAccountSender { get; private set; }
        public int FkAccountReceiver { get; private set; }
        public Account AccountSender { get; private set; }
        public Account AccountReceiver { get; private set; }
    }
}
