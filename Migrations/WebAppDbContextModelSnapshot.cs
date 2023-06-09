﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.data;

#nullable disable

namespace server.Migrations
{
    [DbContext(typeof(WebAppDbContext))]
    partial class WebAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("server.model.OrderModel", b =>
                {
                    b.Property<string>("OrderId")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Detail")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("IfDoneScore")
                        .HasColumnType("int");

                    b.Property<bool?>("IsTaken")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PiorityScore")
                        .HasColumnType("int");

                    b.Property<string>("ReceiveLocation")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("ReceiverId")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("ReceiverTel")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ReceiverUsername")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Restaurant")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("UserId")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("UserTel")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Username")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("server.model.UserModel", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("Failed")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("LastName")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Password")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("Success")
                        .HasColumnType("int");

                    b.Property<string>("Tel")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("UserImg")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Username")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
