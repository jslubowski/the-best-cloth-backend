﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TheBestCloth.DAL.Data;

namespace TheBestCloth.API.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20210310174715_AddUserColumns")]
    partial class AddUserColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TheBestCloth.BLL.ModelDatabase.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("PublicId")
                        .HasColumnType("text");

                    b.Property<int?>("ShoppingItemId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingItemId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("TheBestCloth.BLL.ModelDatabase.ShoppingItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ShoppingItems");
                });

            modelBuilder.Entity("TheBestCloth.BLL.ModelDatabase.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TheBestCloth.BLL.ModelDatabase.Photo", b =>
                {
                    b.HasOne("TheBestCloth.BLL.ModelDatabase.ShoppingItem", "ShoppingItem")
                        .WithMany("Photos")
                        .HasForeignKey("ShoppingItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ShoppingItem");
                });

            modelBuilder.Entity("TheBestCloth.BLL.ModelDatabase.ShoppingItem", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
