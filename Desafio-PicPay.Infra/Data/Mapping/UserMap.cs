using Desafio_PicPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_PicPay.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Ignore(x => x.Id);

            builder.HasKey(x => x.UserId);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(true);

            builder.OwnsOne(x => x.Email)
                .Property(x => x.Address)
                .HasColumnName("email")
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired(true);

            builder.OwnsOne(x => x.Password)
                .Property(x => x.Hash)
                .HasColumnName("Password")
                .HasColumnType("varchar")
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(x => x.DocumentType)
                .HasColumnName("DocumentType")
                .HasColumnType("varchar")
                .HasMaxLength(14)
                .IsRequired(true);

            builder.HasOne(x => x.UserType)
                .WithOne()
                .HasForeignKey<User>(x => x.FkUserType)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
