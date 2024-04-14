﻿// <auto-generated />
using System;
using CodingChallengeMM.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodingChallengeMM.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240414022705_updateTableFinancesAddedProductType")]
    partial class updateTableFinancesAddedProductType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodingChallengeMM.Server.Model.Entities.BlacklistedDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlacklistedDomains");
                });

            modelBuilder.Entity("CodingChallengeMM.Server.Model.Entities.BlacklistedNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlacklistedNumbers");
                });

            modelBuilder.Entity("CodingChallengeMM.Server.Model.Entities.CustomerRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AmountRequired")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("CustomerRequests");
                });

            modelBuilder.Entity("CodingChallengeMM.Server.Model.Entities.Finance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerRequestId")
                        .HasColumnType("int");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RepaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RepaymentFrequency")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRequestId")
                        .IsUnique();

                    b.ToTable("Finance");
                });

            modelBuilder.Entity("CodingChallengeMM.Server.Model.Entities.Finance", b =>
                {
                    b.HasOne("CodingChallengeMM.Server.Model.Entities.CustomerRequest", "CustomerRequest")
                        .WithOne("FinanceDetails")
                        .HasForeignKey("CodingChallengeMM.Server.Model.Entities.Finance", "CustomerRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerRequest");
                });

            modelBuilder.Entity("CodingChallengeMM.Server.Model.Entities.CustomerRequest", b =>
                {
                    b.Navigation("FinanceDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
