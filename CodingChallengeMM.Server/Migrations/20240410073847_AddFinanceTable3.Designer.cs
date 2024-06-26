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
    [Migration("20240410073847_AddFinanceTable3")]
    partial class AddFinanceTable3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodingChallengeMM.Server.Model.BlacklistedDomain", b =>
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

            modelBuilder.Entity("CodingChallengeMM.Server.Model.CustomerRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AmountRequired")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Term")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerRequests");
                });

            modelBuilder.Entity("CodingChallengeMM.Server.Model.Finance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CustomerRequestId")
                        .HasColumnType("int");

                    b.Property<decimal>("RepaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RepaymentFrequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TermInMonths")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRequestId")
                        .IsUnique();

                    b.ToTable("Finance");
                });

            modelBuilder.Entity("CodingChallengeMM.Server.Model.Finance", b =>
                {
                    b.HasOne("CodingChallengeMM.Server.Model.CustomerRequest", "CustomerRequest")
                        .WithOne("FinanceDetails")
                        .HasForeignKey("CodingChallengeMM.Server.Model.Finance", "CustomerRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerRequest");
                });

            modelBuilder.Entity("CodingChallengeMM.Server.Model.CustomerRequest", b =>
                {
                    b.Navigation("FinanceDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
