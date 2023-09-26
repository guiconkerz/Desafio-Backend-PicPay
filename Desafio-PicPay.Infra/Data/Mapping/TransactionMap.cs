using Desafio_PicPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_PicPay.Infra.Data.Mapping
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");

            builder.Ignore(x => x.Id);

            builder.HasKey(x => x.TransactionId);

            builder.Property(x => x.Value)
                .HasColumnName("Value")
                .HasColumnType("decimal(18,0)")
                .IsRequired(true);

            builder.Property(x => x.PreviousValue)
                .HasColumnName("PreviousValue")
                .HasColumnType("decimal(18,0)")
                .IsRequired(true);

            builder.Property(x => x.NewValue)
                .HasColumnName("NewValue")
                .HasColumnType("decimal(18,0)")
                .IsRequired(true);

        }
    }
}
