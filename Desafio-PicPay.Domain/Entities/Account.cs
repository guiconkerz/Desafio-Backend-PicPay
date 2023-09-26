using Desafio_PicPay.Shared.Entities;

namespace Desafio_PicPay.Domain.Entities
{
    public class Account : Entity
    {
        protected Account() { }
        public Account(decimal currentValue, User user)
        {
            CurrentValue = currentValue;
            User = user;
        }

        public int AccountId { get; private set; }
        public decimal CurrentValue { get; private set; }
        public int FkUser { get; private set; }
        public User User { get; private set; }
        public ICollection<Transaction> TransactionsSent { get; private set; }
        public ICollection<Transaction> TransactionsReceived { get; private set; }
    }
}
