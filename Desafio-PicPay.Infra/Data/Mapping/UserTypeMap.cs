using Desafio_PicPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_PicPay.Infra.Data.Mapping
{
    public class UserTypeMap : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.ToTable("UserType");

            builder.Ignore(x => x.Id);

            builder.HasKey(x => x.UserTypeId);

            builder.Property(x => x.Type)
                .HasColumnType("varchar")
                .HasColumnName("Type")
                .HasMaxLength(30)
                .IsRequired(true);
        }
    }
}
