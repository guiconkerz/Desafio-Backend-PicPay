﻿// <auto-generated />
using Desafio_PicPay.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Desafio_PicPay.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Desafio_PicPay.Domain.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<decimal>("CurrentValue")
                        .HasColumnType("decimal(18,0")
                        .HasColumnName("CurrentValue");

                    b.Property<int>("FkUser")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("FkUser")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Desafio_PicPay.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<int>("FkAccountReceiver")
                        .HasColumnType("int");

                    b.Property<int>("FkAccountSender")
                        .HasColumnType("int");

                    b.Property<decimal>("NewValue")
                        .HasColumnType("decimal(18,0")
                        .HasColumnName("NewValue");

                    b.Property<decimal>("PreviousValue")
                        .HasColumnType("decimal(18,0")
                        .HasColumnName("PreviousValue");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,0")
                        .HasColumnName("Value");

                    b.HasKey("TransactionId");

                    b.HasIndex("FkAccountReceiver");

                    b.HasIndex("FkAccountSender");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("Desafio_PicPay.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar")
                        .HasColumnName("DocumentType");

                    b.Property<int>("FkUserType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("FkUserType")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Desafio_PicPay.Domain.Entities.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTypeId"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("Type");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserType", (string)null);
                });

            modelBuilder.Entity("Desafio_PicPay.Domain.Entities.Account", b =>
                {
                    b.HasOne("Desafio_PicPay.Domain.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("Desafio_PicPay.Domain.Entities.Account", "FkUser")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Desafio_PicPay.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("Desafio_PicPay.Domain.Entities.Account", "AccountReceiver")
                        .WithMany("TransactionsReceived")
                        .HasForeignKey("FkAccountReceiver")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Desafio_PicPay.Domain.Entities.Account", "AccountSender")
                        .WithMany("TransactionsSent")
                        .HasForeignKey("FkAccountSender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountReceiver");

                    b.Navigation("AccountSender");
                });

            modelBuilder.Entity("Desafio_PicPay.Domain.Entities.User", b =>
                {
                    b.HasOne("Desafio_PicPay.Domain.Entities.UserType", "UserType")
                        .WithOne()
                        .HasForeignKey("Desafio_PicPay.Domain.Entities.User", "FkUserType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("Desafio_PicPay.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("varchar")
                                .HasColumnName("email");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Desafio_PicPay.Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Hash")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("varchar")
                                .HasColumnName("Password");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Desafio_PicPay.Domain.Entities.Account", b =>
                {
                    b.Navigation("TransactionsReceived");

                    b.Navigation("TransactionsSent");
                });
#pragma warning restore 612, 618
        }
    }
}