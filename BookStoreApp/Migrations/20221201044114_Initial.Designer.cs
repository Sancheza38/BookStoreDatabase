﻿// <auto-generated />
using System;
using BookStoreApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreApp.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20221201044114_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreApp.Models.Assigned", b =>
                {
                    b.Property<int>("CategoryCode")
                        .HasColumnType("int");

                    b.Property<long>("ISBN")
                        .HasColumnType("bigint");

                    b.HasKey("CategoryCode", "ISBN");

                    b.HasIndex("ISBN");

                    b.ToTable("Assigned");
                });

            modelBuilder.Entity("BookStoreApp.Models.AuthorAddressDetails", b =>
                {
                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContactID", "Address");

                    b.ToTable("AuthorAddressDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.AuthorContactDetails", b =>
                {
                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.HasKey("ContactID");

                    b.ToTable("AuthorContactDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.AuthorEmailDetails", b =>
                {
                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContactID", "Email");

                    b.ToTable("AuthorEmailDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.AuthorOfBooks", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.ToTable("AuthorOfBooks", (string)null);
                });

            modelBuilder.Entity("BookStoreApp.Models.AuthorPhoneDetails", b =>
                {
                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContactID", "Phone");

                    b.ToTable("AuthorPhoneDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.Book", b =>
                {
                    b.Property<long>("ISBN")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserReview")
                        .HasColumnType("int");

                    b.HasKey("ISBN");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("BookStoreApp.Models.BookCategory", b =>
                {
                    b.Property<int>("CategoryCode")
                        .HasColumnType("int");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryCode");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("BookStoreApp.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("BookStoreApp.Models.CustomerAddressDetails", b =>
                {
                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContactID", "Address");

                    b.ToTable("CustomerAddressDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.CustomerContactDetails", b =>
                {
                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.HasKey("ContactID");

                    b.ToTable("CustomerContactDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.CustomerEmailDetails", b =>
                {
                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContactID", "Email");

                    b.ToTable("CustomerEmailDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.CustomerPhoneDetails", b =>
                {
                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContactID", "Phone");

                    b.ToTable("CustomerPhoneDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("OrderDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OrderValue")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("BookStoreApp.Models.OrderItem", b =>
                {
                    b.Property<int>("ItemNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemNumber"));

                    b.Property<long>("ISBN")
                        .HasColumnType("bigint");

                    b.Property<decimal>("ItemPrice")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.HasKey("ItemNumber");

                    b.HasIndex("ISBN");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("BookStoreApp.Models.Supplier", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("BookStoreApp.Models.SupplierRep", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CellNumber")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.Property<int>("WorkNumber")
                        .HasColumnType("int");

                    b.HasKey("Email");

                    b.HasIndex("SupplierID");

                    b.ToTable("SupplierRep");
                });

            modelBuilder.Entity("BookStoreApp.Models.Supplies", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<long>("ISBN")
                        .HasColumnType("bigint");

                    b.HasKey("ID", "ISBN");

                    b.HasIndex("ISBN");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("BookStoreApp.Models.Write", b =>
                {
                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<long>("ISBN")
                        .HasColumnType("bigint");

                    b.HasKey("AuthorID", "ISBN");

                    b.HasIndex("ISBN");

                    b.ToTable("Write", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BookStoreApp.Models.Assigned", b =>
                {
                    b.HasOne("BookStoreApp.Models.BookCategory", "BooksCategories")
                        .WithMany("Assigns")
                        .HasForeignKey("CategoryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreApp.Models.Book", "Books")
                        .WithMany("Assigns")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("BooksCategories");
                });

            modelBuilder.Entity("BookStoreApp.Models.AuthorAddressDetails", b =>
                {
                    b.HasOne("BookStoreApp.Models.AuthorContactDetails", "AuthorContactDetails")
                        .WithMany("AddressDetails")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorContactDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.AuthorContactDetails", b =>
                {
                    b.HasOne("BookStoreApp.Models.AuthorOfBooks", "AuthorOfBooks")
                        .WithOne("AuthorContactDetails")
                        .HasForeignKey("BookStoreApp.Models.AuthorContactDetails", "ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorOfBooks");
                });

            modelBuilder.Entity("BookStoreApp.Models.AuthorEmailDetails", b =>
                {
                    b.HasOne("BookStoreApp.Models.AuthorContactDetails", "AuthorContactDetails")
                        .WithMany("EmailDetails")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorContactDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.AuthorPhoneDetails", b =>
                {
                    b.HasOne("BookStoreApp.Models.AuthorContactDetails", "AuthorContactDetails")
                        .WithMany("PhoneDetails")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorContactDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.CustomerAddressDetails", b =>
                {
                    b.HasOne("BookStoreApp.Models.CustomerContactDetails", "CustomerContactDetails")
                        .WithMany("AddressDetails")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerContactDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.CustomerContactDetails", b =>
                {
                    b.HasOne("BookStoreApp.Models.Customer", "Customer")
                        .WithOne("CustomerContactDetails")
                        .HasForeignKey("BookStoreApp.Models.CustomerContactDetails", "ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BookStoreApp.Models.CustomerEmailDetails", b =>
                {
                    b.HasOne("BookStoreApp.Models.CustomerContactDetails", "CustomerContactDetails")
                        .WithMany("EmailDetails")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerContactDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.CustomerPhoneDetails", b =>
                {
                    b.HasOne("BookStoreApp.Models.CustomerContactDetails", "CustomerContactDetails")
                        .WithMany("PhoneDetails")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerContactDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.Order", b =>
                {
                    b.HasOne("BookStoreApp.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BookStoreApp.Models.OrderItem", b =>
                {
                    b.HasOne("BookStoreApp.Models.Book", "Books")
                        .WithMany("OrderItems")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreApp.Models.Order", "Orders")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BookStoreApp.Models.SupplierRep", b =>
                {
                    b.HasOne("BookStoreApp.Models.Supplier", "Supplier")
                        .WithMany("SupplierRep")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("BookStoreApp.Models.Supplies", b =>
                {
                    b.HasOne("BookStoreApp.Models.Supplier", "Supplier")
                        .WithMany("Supplies")
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreApp.Models.Book", "Books")
                        .WithMany("Supplies")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("BookStoreApp.Models.Write", b =>
                {
                    b.HasOne("BookStoreApp.Models.AuthorOfBooks", "AuthorOfBooks")
                        .WithMany("Writes")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreApp.Models.Book", "Books")
                        .WithMany("Writes")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorOfBooks");

                    b.Navigation("Books");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookStoreApp.Models.AuthorContactDetails", b =>
                {
                    b.Navigation("AddressDetails");

                    b.Navigation("EmailDetails");

                    b.Navigation("PhoneDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.AuthorOfBooks", b =>
                {
                    b.Navigation("AuthorContactDetails");

                    b.Navigation("Writes");
                });

            modelBuilder.Entity("BookStoreApp.Models.Book", b =>
                {
                    b.Navigation("Assigns");

                    b.Navigation("OrderItems");

                    b.Navigation("Supplies");

                    b.Navigation("Writes");
                });

            modelBuilder.Entity("BookStoreApp.Models.BookCategory", b =>
                {
                    b.Navigation("Assigns");
                });

            modelBuilder.Entity("BookStoreApp.Models.Customer", b =>
                {
                    b.Navigation("CustomerContactDetails");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BookStoreApp.Models.CustomerContactDetails", b =>
                {
                    b.Navigation("AddressDetails");

                    b.Navigation("EmailDetails");

                    b.Navigation("PhoneDetails");
                });

            modelBuilder.Entity("BookStoreApp.Models.Supplier", b =>
                {
                    b.Navigation("SupplierRep");

                    b.Navigation("Supplies");
                });
#pragma warning restore 612, 618
        }
    }
}
