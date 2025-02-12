﻿// <auto-generated />
using System;
using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dal.Migrations
{
    [DbContext(typeof(CarContext))]
    [Migration("20220627141625_updatelast")]
    partial class updatelast
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dal.Models.Bill", b =>
                {
                    b.Property<int>("billId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("carServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("price")
                        .HasColumnType("int");

                    b.Property<string>("work")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("billId");

                    b.HasIndex("carServiceId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("Dal.Models.CarService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("appointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("approxCost")
                        .HasColumnType("int");

                    b.Property<int?>("bodyClean")
                        .HasColumnType("int");

                    b.Property<string>("carFuelType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("carManufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("carModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("garageId")
                        .HasColumnType("int");

                    b.Property<bool?>("isActive")
                        .HasColumnType("bit");

                    b.Property<int?>("keyRegistration")
                        .HasColumnType("int");

                    b.Property<int?>("oneSidePickOrDrop")
                        .HasColumnType("int");

                    b.Property<int?>("pickupAndDrop")
                        .HasColumnType("int");

                    b.Property<int?>("pickupOrDrop")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ratingDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("ratings")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("serviceCharge")
                        .HasColumnType("int");

                    b.Property<int?>("totalCost")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.Property<int?>("washAndClean")
                        .HasColumnType("int");

                    b.Property<int?>("wheelAlignment")
                        .HasColumnType("int");

                    b.Property<int?>("wheelBalancing")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("garageId");

                    b.HasIndex("userId");

                    b.ToTable("CarService");
                });

            modelBuilder.Entity("Dal.Models.Garage", b =>
                {
                    b.Property<int>("GarageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("addressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("addressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("bodyClean")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("garageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isActive")
                        .HasColumnType("bit");

                    b.Property<int?>("keyRegistration")
                        .HasColumnType("int");

                    b.Property<int?>("oneSidePickOrDrop")
                        .HasColumnType("int");

                    b.Property<int?>("pickupAndDrop")
                        .HasColumnType("int");

                    b.Property<int?>("pickupOrDrop")
                        .HasColumnType("int");

                    b.Property<string>("postalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("serviceCharge")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int?>("washAndClean")
                        .HasColumnType("int");

                    b.Property<int?>("wheelAlignment")
                        .HasColumnType("int");

                    b.Property<int?>("wheelBalancing")
                        .HasColumnType("int");

                    b.HasKey("GarageId");

                    b.HasIndex("userId");

                    b.ToTable("Garage");
                });

            modelBuilder.Entity("Dal.Models.InvoiceInfo", b =>
                {
                    b.Property<int>("invoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("billId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("finalCost")
                        .HasColumnType("int");

                    b.Property<int>("garageId")
                        .HasColumnType("int");

                    b.Property<int?>("gst")
                        .HasColumnType("int");

                    b.Property<int?>("mobile")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("invoiceId");

                    b.HasIndex("billId");

                    b.HasIndex("garageId");

                    b.HasIndex("userId");

                    b.ToTable("InvoiceInfo");
                });

            modelBuilder.Entity("Dal.Models.MechanicService", b =>
                {
                    b.Property<int>("mechanicServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("acceptDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("billStatus")
                        .HasColumnType("bit");

                    b.Property<int?>("carServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("estimateDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("serviceStatus")
                        .HasColumnType("bit");

                    b.HasKey("mechanicServiceId");

                    b.HasIndex("carServiceId");

                    b.ToTable("MechanicService");
                });

            modelBuilder.Entity("Dal.Models.UserAddress", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAddress");
                });

            modelBuilder.Entity("Dal.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("addressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("addressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Dal.Models.package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("bodyClean")
                        .HasColumnType("int");

                    b.Property<int?>("keyRegistration")
                        .HasColumnType("int");

                    b.Property<int?>("oneSidePickOrDrop")
                        .HasColumnType("int");

                    b.Property<int?>("pickupAndDrop")
                        .HasColumnType("int");

                    b.Property<int?>("pickupOrDrop")
                        .HasColumnType("int");

                    b.Property<int?>("serviceCharge")
                        .HasColumnType("int");

                    b.Property<int?>("washAndClean")
                        .HasColumnType("int");

                    b.Property<int?>("wheelAlignment")
                        .HasColumnType("int");

                    b.Property<int?>("wheelBalancing")
                        .HasColumnType("int");

                    b.HasKey("PackageId");

                    b.HasIndex("UserId");

                    b.ToTable("package");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Dal.Models.Bill", b =>
                {
                    b.HasOne("Dal.Models.CarService", "CarService")
                        .WithMany()
                        .HasForeignKey("carServiceId");
                });

            modelBuilder.Entity("Dal.Models.CarService", b =>
                {
                    b.HasOne("Dal.Models.Garage", "Garage")
                        .WithMany()
                        .HasForeignKey("garageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dal.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Dal.Models.Garage", b =>
                {
                    b.HasOne("Dal.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dal.Models.InvoiceInfo", b =>
                {
                    b.HasOne("Dal.Models.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("billId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dal.Models.Garage", "Garage")
                        .WithMany()
                        .HasForeignKey("garageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dal.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dal.Models.MechanicService", b =>
                {
                    b.HasOne("Dal.Models.CarService", "CarService")
                        .WithMany()
                        .HasForeignKey("carServiceId");
                });

            modelBuilder.Entity("Dal.Models.UserAddress", b =>
                {
                    b.HasOne("Dal.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dal.Models.package", b =>
                {
                    b.HasOne("Dal.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Dal.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Dal.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dal.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Dal.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
