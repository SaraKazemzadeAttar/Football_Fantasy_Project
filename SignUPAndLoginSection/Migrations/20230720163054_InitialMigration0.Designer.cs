﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignUPAndLoginSection.DataAccessLayer;

#nullable disable

namespace SignUPAndLoginSection.Migrations
{
    [DbContext(typeof(DataBase))]
    [Migration("20230720163054_InitialMigration0")]
    partial class InitialMigration0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1");

            modelBuilder.Entity("SignUPAndLoginSection.DataAccessLayer.UsersTeamPlayers", b =>
                {
                    b.Property<int>("UsersTeamPlayersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("playerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("roleOfPLayer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UsersTeamPlayersId");

                    b.ToTable("UsersTeamPlayersTable");
                });

            modelBuilder.Entity("SignUPAndLoginSection.businessLayer.Player", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("element_type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("now_cost")
                        .HasColumnType("REAL");

                    b.Property<string>("photo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("second_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("team")
                        .HasColumnType("INTEGER");

                    b.Property<double>("total_points")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.ToTable("playerTable");
                });

            modelBuilder.Entity("SignUPAndLoginSection.presentationLayer.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("OTPCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Score")
                        .HasColumnType("REAL");

                    b.Property<double>("cash")
                        .HasColumnType("REAL");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isvalid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("mobilePhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("userId");

                    b.ToTable("userTable");
                });
#pragma warning restore 612, 618
        }
    }
}
