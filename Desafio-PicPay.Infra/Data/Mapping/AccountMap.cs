using Desafio_PicPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_PicPay.Infra.Data.Mapping
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.Ignore(x => x.Id);

            builder.HasKey(x => x.AccountId);

            builder.Property(x => x.CurrentValue)
                .HasColumnName("CurrentValue")
                .HasColumnType("decimal(18,0")
                .IsRequired(true);

            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Account>(x => x.FkUser)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.TransactionsSent)
                .WithOne(x => x.AccountSender)
                .HasForeignKey(x => x.FkAccountSender);

            builder.HasMany(x => x.TransactionsReceived)
                .WithOne(x => x.AccountReceiver)
                .HasForeignKey(x => x.FkAccountReceiver);
        }
    }
}
