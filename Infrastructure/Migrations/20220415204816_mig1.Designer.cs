﻿// <auto-generated />
using System;
using Infrastructure.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220415204816_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Concrete.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("addressid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("AddressInfo")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar")
                        .HasColumnName("addressinfo")
                        .HasColumnOrder(6);

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar")
                        .HasColumnName("addresstype")
                        .HasColumnOrder(2);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("country")
                        .HasColumnOrder(3);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar")
                        .HasColumnName("createdby")
                        .HasColumnOrder(11);

                    b.Property<decimal>("CreatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("createddate")
                        .HasColumnOrder(9);

                    b.Property<decimal>("CreatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("createdtime")
                        .HasColumnOrder(10);

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar")
                        .HasColumnName("district")
                        .HasColumnOrder(5);

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("isdefault")
                        .HasColumnOrder(8);

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar")
                        .HasColumnName("mobileno")
                        .HasColumnOrder(7);

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("province")
                        .HasColumnOrder(4);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar")
                        .HasColumnName("updatedby")
                        .HasColumnOrder(14);

                    b.Property<decimal?>("UpdatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("updateddate")
                        .HasColumnOrder(12);

                    b.Property<decimal?>("UpdatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("updatedtime")
                        .HasColumnOrder(13);

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("address", "entity");

                    b.HasComment("Holds users and purchases adresses");
                });

            modelBuilder.Entity("Entities.Concrete.Api", b =>
                {
                    b.Property<Guid>("ApiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("apiid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("ApiRoute")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("apiroute")
                        .HasColumnOrder(2);

                    b.HasKey("ApiId");

                    b.HasAlternateKey("ApiRoute");

                    b.ToTable("api", "system");

                    b.HasComment("Holds api");
                });

            modelBuilder.Entity("Entities.Concrete.ApiLog", b =>
                {
                    b.Property<Guid>("ApiLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("apilogid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<decimal>("CreatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("createddate")
                        .HasColumnOrder(10);

                    b.Property<decimal>("CreatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("createdtime")
                        .HasColumnOrder(11);

                    b.Property<decimal>("Duration")
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("duration")
                        .HasColumnOrder(9);

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("method")
                        .HasColumnOrder(4);

                    b.Property<string>("Request")
                        .HasColumnType("text")
                        .HasColumnName("request")
                        .HasColumnOrder(7);

                    b.Property<string>("Response")
                        .HasColumnType("text")
                        .HasColumnName("response")
                        .HasColumnOrder(8);

                    b.Property<string>("RouteUrl")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("routeurl")
                        .HasColumnOrder(6);

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("servicename")
                        .HasColumnOrder(5);

                    b.Property<decimal>("StatusCode")
                        .HasPrecision(3)
                        .HasColumnType("numeric(3)")
                        .HasColumnName("statuscode")
                        .HasColumnOrder(3);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username")
                        .HasColumnOrder(2);

                    b.HasKey("ApiLogId");

                    b.ToTable("apilog", "system");

                    b.HasComment("Holds api logs");
                });

            modelBuilder.Entity("Entities.Concrete.ApiRole", b =>
                {
                    b.Property<Guid>("ApiId")
                        .HasColumnType("uuid")
                        .HasColumnName("apiid")
                        .HasColumnOrder(1);

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("roleid")
                        .HasColumnOrder(2);

                    b.HasKey("ApiId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("apirole", "system");

                    b.HasComment("Holds api's roles");
                });

            modelBuilder.Entity("Entities.Concrete.Cart", b =>
                {
                    b.Property<Guid>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("cartid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userid")
                        .HasColumnOrder(2);

                    b.HasKey("CartId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("cart", "entity");

                    b.HasComment("Holds user's cart");
                });

            modelBuilder.Entity("Entities.Concrete.CartProduct", b =>
                {
                    b.Property<Guid>("CartId")
                        .HasColumnType("uuid")
                        .HasColumnName("cartid")
                        .HasColumnOrder(1);

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("productid")
                        .HasColumnOrder(2);

                    b.HasKey("CartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("cart_product", "entity");

                    b.HasComment("Holds cart's products");
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("categoryid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasColumnOrder(2);

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("parentcategoryid")
                        .HasColumnOrder(3);

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId")
                        .IsUnique();

                    b.ToTable("category", "entity");

                    b.HasComment("Holds categories");
                });

            modelBuilder.Entity("Entities.Concrete.Media", b =>
                {
                    b.Property<Guid>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("mediaid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar")
                        .HasColumnName("createdby")
                        .HasColumnOrder(7);

                    b.Property<decimal>("CreatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("createddate")
                        .HasColumnOrder(5);

                    b.Property<decimal>("CreatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("createdtime")
                        .HasColumnOrder(6);

                    b.Property<bool>("IsCoverPhoto")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasColumnOrder(2);

                    b.Property<decimal>("Order")
                        .HasPrecision(2)
                        .HasColumnType("numeric(2)")
                        .HasColumnName("order")
                        .HasColumnOrder(4);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("path")
                        .HasColumnOrder(3);

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar")
                        .HasColumnName("updatedby")
                        .HasColumnOrder(10);

                    b.Property<decimal?>("UpdatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("updateddate")
                        .HasColumnOrder(8);

                    b.Property<decimal?>("UpdatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("updatedtime")
                        .HasColumnOrder(9);

                    b.HasKey("MediaId");

                    b.HasIndex("ProductId");

                    b.ToTable("media", "entity");

                    b.HasComment("Holds medias");
                });

            modelBuilder.Entity("Entities.Concrete.Merchant", b =>
                {
                    b.Property<Guid>("MerchantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("merchantid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar")
                        .HasColumnName("createdby")
                        .HasColumnOrder(7);

                    b.Property<decimal>("CreatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("createddate")
                        .HasColumnOrder(5);

                    b.Property<decimal>("CreatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("createdtime")
                        .HasColumnOrder(6);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("isdeleted")
                        .HasColumnOrder(4);

                    b.Property<string>("MerchantName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar")
                        .HasColumnName("merchantname")
                        .HasColumnOrder(2);

                    b.Property<decimal>("MerchantPoint")
                        .HasPrecision(2, 1)
                        .HasColumnType("numeric(2,1)")
                        .HasColumnName("merchantpoint")
                        .HasColumnOrder(3);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar")
                        .HasColumnName("updatedby")
                        .HasColumnOrder(10);

                    b.Property<decimal?>("UpdatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("updateddate")
                        .HasColumnOrder(8);

                    b.Property<decimal?>("UpdatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("updatedtime")
                        .HasColumnOrder(9);

                    b.HasKey("MerchantId");

                    b.HasIndex("AddressId");

                    b.ToTable("merchant", "entity");

                    b.HasComment("Holds merchants");
                });

            modelBuilder.Entity("Entities.Concrete.Notification", b =>
                {
                    b.Property<Guid>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar")
                        .HasColumnName("createdby")
                        .HasColumnOrder(9);

                    b.Property<decimal>("CreatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("createddate")
                        .HasColumnOrder(7);

                    b.Property<decimal>("CreatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("createdtime")
                        .HasColumnOrder(8);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnOrder(6);

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar")
                        .HasColumnOrder(4);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnOrder(5);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnOrder(2);

                    b.Property<string>("TypeSymbol")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnOrder(3);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar")
                        .HasColumnName("updatedby")
                        .HasColumnOrder(12);

                    b.Property<decimal?>("UpdatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("updateddate")
                        .HasColumnOrder(10);

                    b.Property<decimal?>("UpdatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("updatedtime")
                        .HasColumnOrder(11);

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications", t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("Entities.Concrete.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("productid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar")
                        .HasColumnName("createdby")
                        .HasColumnOrder(6);

                    b.Property<decimal>("CreatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("createddate")
                        .HasColumnOrder(4);

                    b.Property<decimal>("CreatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("createdtime")
                        .HasColumnOrder(5);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("isdeleted")
                        .HasColumnOrder(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasColumnOrder(2);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar")
                        .HasColumnName("updatedby")
                        .HasColumnOrder(9);

                    b.Property<decimal?>("UpdatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("updateddate")
                        .HasColumnOrder(7);

                    b.Property<decimal?>("UpdatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("updatedtime")
                        .HasColumnOrder(8);

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("product", "entity");

                    b.HasComment("Holds products");
                });

            modelBuilder.Entity("Entities.Concrete.ProductDetail", b =>
                {
                    b.Property<Guid>("ProductDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("productdetailid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("color")
                        .HasColumnOrder(5);

                    b.Property<decimal>("Count")
                        .HasPrecision(10)
                        .HasColumnType("numeric(10)")
                        .HasColumnName("count")
                        .HasColumnOrder(2);

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("varchar")
                        .HasColumnName("detail")
                        .HasColumnOrder(4);

                    b.Property<Guid?>("MerchantId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasPrecision(15, 2)
                        .HasColumnType("numeric(15,2)")
                        .HasColumnName("price")
                        .HasColumnOrder(3);

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<decimal?>("Size")
                        .HasMaxLength(250)
                        .HasColumnType("numeric")
                        .HasColumnName("size")
                        .HasColumnOrder(6);

                    b.HasKey("ProductDetailId");

                    b.HasIndex("MerchantId");

                    b.HasIndex("ProductId");

                    b.ToTable("productdetail", "entity");

                    b.HasComment("Holds product's details");
                });

            modelBuilder.Entity("Entities.Concrete.Purchase", b =>
                {
                    b.Property<Guid>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("purchaseid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("createddate")
                        .HasColumnOrder(3);

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(15, 2)
                        .HasColumnType("numeric(15,2)")
                        .HasColumnName("totalprice")
                        .HasColumnOrder(2);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updateddate")
                        .HasColumnOrder(4);

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("PurchaseId");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("purchase", "entity");

                    b.HasComment("Holds purschases");
                });

            modelBuilder.Entity("Entities.Concrete.PurchasedProduct", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("productid")
                        .HasColumnOrder(2);

                    b.Property<Guid>("PurchaseId")
                        .HasColumnType("uuid")
                        .HasColumnName("purchaseid")
                        .HasColumnOrder(1);

                    b.HasKey("ProductId", "PurchaseId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("purchased_product", "entity");

                    b.HasComment("Holds pursches's products");
                });

            modelBuilder.Entity("Entities.Concrete.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("roleid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("rolename")
                        .HasColumnOrder(2);

                    b.HasKey("RoleId");

                    b.HasAlternateKey("RoleName");

                    b.ToTable("role", "system");

                    b.HasComment("Holds roles");
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("userid")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<decimal>("BirthDate")
                        .HasPrecision(8)
                        .HasColumnType("numeric(8)")
                        .HasColumnName("birthdate")
                        .HasColumnOrder(8);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar")
                        .HasColumnName("createdby")
                        .HasColumnOrder(13);

                    b.Property<decimal>("CreatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("createddate")
                        .HasColumnOrder(11);

                    b.Property<decimal>("CreatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("createdtime")
                        .HasColumnOrder(12);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar")
                        .HasColumnName("email")
                        .HasColumnOrder(5);

                    b.Property<string>("Gender")
                        .HasColumnType("varchar")
                        .HasColumnName("gender")
                        .HasColumnOrder(7);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("isdeleted")
                        .HasColumnOrder(10);

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("mobileno")
                        .HasColumnOrder(6);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasColumnOrder(2);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("password")
                        .HasColumnOrder(9);

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("surname")
                        .HasColumnOrder(3);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar")
                        .HasColumnName("updatedby")
                        .HasColumnOrder(16);

                    b.Property<decimal?>("UpdatedDate")
                        .HasColumnType("numeric")
                        .HasColumnName("updateddate")
                        .HasColumnOrder(14);

                    b.Property<decimal?>("UpdatedTime")
                        .HasColumnType("numeric")
                        .HasColumnName("updatedtime")
                        .HasColumnOrder(15);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("username")
                        .HasColumnOrder(4);

                    b.HasKey("UserId");

                    b.ToTable("user", "entity");

                    b.HasComment("Holds user's information");
                });

            modelBuilder.Entity("Entities.Concrete.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userid")
                        .HasColumnOrder(1);

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("roleid")
                        .HasColumnOrder(2);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("userrole", "system");

                    b.HasComment("Holds user's roles");
                });

            modelBuilder.Entity("Entities.Concrete.Address", b =>
                {
                    b.HasOne("Entities.Concrete.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concrete.ApiRole", b =>
                {
                    b.HasOne("Entities.Concrete.Api", "Api")
                        .WithMany("ApiRoles")
                        .HasForeignKey("ApiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Role", "Role")
                        .WithMany("ApiRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Api");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Entities.Concrete.Cart", b =>
                {
                    b.HasOne("Entities.Concrete.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("Entities.Concrete.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concrete.CartProduct", b =>
                {
                    b.HasOne("Entities.Concrete.Cart", "Cart")
                        .WithMany("CartProducts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Product", "Product")
                        .WithMany("CartProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.HasOne("Entities.Concrete.Category", "ParentCategory")
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.Category", "ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Entities.Concrete.Media", b =>
                {
                    b.HasOne("Entities.Concrete.Product", "Product")
                        .WithMany("Medias")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Concrete.Merchant", b =>
                {
                    b.HasOne("Entities.Concrete.Address", "Address")
                        .WithMany("Merchants")
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Entities.Concrete.Product", b =>
                {
                    b.HasOne("Entities.Concrete.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.Concrete.ProductDetail", b =>
                {
                    b.HasOne("Entities.Concrete.Merchant", "Merchant")
                        .WithMany("ProductDetails")
                        .HasForeignKey("MerchantId");

                    b.HasOne("Entities.Concrete.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductId");

                    b.Navigation("Merchant");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Concrete.Purchase", b =>
                {
                    b.HasOne("Entities.Concrete.Address", "Address")
                        .WithMany("Purchases")
                        .HasForeignKey("AddressId");

                    b.HasOne("Entities.Concrete.User", "User")
                        .WithMany("Purchases")
                        .HasForeignKey("UserId");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concrete.PurchasedProduct", b =>
                {
                    b.HasOne("Entities.Concrete.Product", "Product")
                        .WithMany("PurchasedProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Purchase", "Purchase")
                        .WithMany("PurchasedProducts")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Entities.Concrete.UserRole", b =>
                {
                    b.HasOne("Entities.Concrete.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concrete.Address", b =>
                {
                    b.Navigation("Merchants");

                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("Entities.Concrete.Api", b =>
                {
                    b.Navigation("ApiRoles");
                });

            modelBuilder.Entity("Entities.Concrete.Cart", b =>
                {
                    b.Navigation("CartProducts");
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Concrete.Merchant", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("Entities.Concrete.Product", b =>
                {
                    b.Navigation("CartProducts");

                    b.Navigation("Medias");

                    b.Navigation("ProductDetails");

                    b.Navigation("PurchasedProducts");
                });

            modelBuilder.Entity("Entities.Concrete.Purchase", b =>
                {
                    b.Navigation("PurchasedProducts");
                });

            modelBuilder.Entity("Entities.Concrete.Role", b =>
                {
                    b.Navigation("ApiRoles");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Cart");

                    b.Navigation("Purchases");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
