﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WalletPlanifier.DataAccess;

namespace WalletPlanifier.DataAccess.Migrations
{
    [DbContext(typeof(WalletPlanifierDBContext))]
    [Migration("20210810143116_TransactionAddTitleField")]
    partial class TransactionAddTitleField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WalletPlanifier.Domain.Transactions.Debt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<int>("FrecuencyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsFixed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FrecuencyId");

                    b.HasIndex("UserId");

                    b.ToTable("Debt");
                });

            modelBuilder.Entity("WalletPlanifier.Domain.Transactions.Frecuency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AmountInDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Frecuency");
                });

            modelBuilder.Entity("WalletPlanifier.Domain.Transactions.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("FrecuencyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FrecuencyId");

                    b.HasIndex("UserId");

                    b.ToTable("Income");
                });

            modelBuilder.Entity("WalletPlanifier.Domain.Transactions.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CompletedTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DebtId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("FinalWalletValue")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("IncomeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<decimal>("OriginWalletValue")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DebtId");

                    b.HasIndex("IncomeId");

                    b.HasIndex("UserId");

                    b.HasIndex("WalletId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("WalletPlanifier.Domain.Transactions.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("WalletPlanifier.Domain.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Profession")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WalletPlanifier.Domain.Users.WishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("AmountNeeded")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DeleterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsGranted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WishList");
                });

            modelBuilder.Entity("WalletPlanifier.Domain.Transactions.Debt", b =>
                {
                    b.HasOne("WalletPlanifier.Domain.Transactions.Frecuency", "Frecuency")
                        .WithMany()
                        .HasForeignKey("FrecuencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalletPlanifier.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WalletPlanifier.Domain.Transactions.Income", b =>
                {
                    b.HasOne("WalletPlanifier.Domain.Transactions.Frecuency", "Frecuency")
                        .WithMany()
                        .HasForeignKey("FrecuencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalletPlanifier.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WalletPlanifier.Domain.Transactions.Transaction", b =>
                {
                    b.HasOne("WalletPlanifier.Domain.Transactions.Debt", "Debt")
                        .WithMany()
                        .HasForeignKey("DebtId");

                    b.HasOne("WalletPlanifier.Domain.Transactions.Income", "Income")
                        .WithMany("Transactions")
                        .HasForeignKey("IncomeId");

                    b.HasOne("WalletPlanifier.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalletPlanifier.Domain.Transactions.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WalletPlanifier.Domain.Transactions.Wallet", b =>
                {
                    b.HasOne("WalletPlanifier.Domain.Users.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
