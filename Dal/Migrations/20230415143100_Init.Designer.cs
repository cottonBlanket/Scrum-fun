﻿// <auto-generated />
using System;
using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dal.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230415143100_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dal.Exercise.ExerciseDal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ModeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ModeId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("Dal.Mode.ModeDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Time")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Mode");
                });

            modelBuilder.Entity("Dal.Room.RoomDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Password")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Dal.User.UserDal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<int?>("RoomDalId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoomDalId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ModeDalRoomDal", b =>
                {
                    b.Property<int>("ModesId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomsId")
                        .HasColumnType("integer");

                    b.HasKey("ModesId", "RoomsId");

                    b.HasIndex("RoomsId");

                    b.ToTable("ModeDalRoomDal");
                });

            modelBuilder.Entity("Dal.Exercise.ExerciseDal", b =>
                {
                    b.HasOne("Dal.Mode.ModeDal", "Mode")
                        .WithMany("Exercises")
                        .HasForeignKey("ModeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mode");
                });

            modelBuilder.Entity("Dal.User.UserDal", b =>
                {
                    b.HasOne("Dal.Room.RoomDal", null)
                        .WithMany("Users")
                        .HasForeignKey("RoomDalId");
                });

            modelBuilder.Entity("ModeDalRoomDal", b =>
                {
                    b.HasOne("Dal.Mode.ModeDal", null)
                        .WithMany()
                        .HasForeignKey("ModesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dal.Room.RoomDal", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dal.Mode.ModeDal", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("Dal.Room.RoomDal", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}