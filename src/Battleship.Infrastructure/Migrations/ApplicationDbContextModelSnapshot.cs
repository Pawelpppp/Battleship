﻿// <auto-generated />
using System;
using Battleship.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Battleship.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("BattleshipDB")
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Battleship.Domain.Entities.Battleship", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BoardId")
                        .HasColumnType("bigint")
                        .HasColumnName("board_id");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDestroyed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("isDestroyed");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Battleship", "BattleshipDB");
                });

            modelBuilder.Entity("Battleship.Domain.Entities.Board", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creationDate")
                        .HasDefaultValueSql("NOW()");

                    b.Property<long?>("GameId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsBattleshipsDestyroyed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("isBattleshipsDestyroyed");

                    b.Property<DateTimeOffset?>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lastModified")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Board", "BattleshipDB");
                });

            modelBuilder.Entity("Battleship.Domain.Entities.Field", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("BattleshipId")
                        .HasColumnType("bigint");

                    b.Property<long?>("BoardId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BattleshipId");

                    b.HasIndex("BoardId");

                    b.ToTable("Field", "BattleshipDB");
                });

            modelBuilder.Entity("Battleship.Domain.Entities.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Games", "BattleshipDB");
                });

            modelBuilder.Entity("Battleship.Domain.Entities.Battleship", b =>
                {
                    b.HasOne("Battleship.Domain.Entities.Board", "Board")
                        .WithMany("Battleships")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("Battleship.Domain.Entities.Board", b =>
                {
                    b.HasOne("Battleship.Domain.Entities.Game", null)
                        .WithMany("Boards")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("Battleship.Domain.Entities.Field", b =>
                {
                    b.HasOne("Battleship.Domain.Entities.Battleship", null)
                        .WithMany("Area")
                        .HasForeignKey("BattleshipId");

                    b.HasOne("Battleship.Domain.Entities.Board", null)
                        .WithMany("Shots")
                        .HasForeignKey("BoardId");
                });

            modelBuilder.Entity("Battleship.Domain.Entities.Battleship", b =>
                {
                    b.Navigation("Area");
                });

            modelBuilder.Entity("Battleship.Domain.Entities.Board", b =>
                {
                    b.Navigation("Battleships");

                    b.Navigation("Shots");
                });

            modelBuilder.Entity("Battleship.Domain.Entities.Game", b =>
                {
                    b.Navigation("Boards");
                });
#pragma warning restore 612, 618
        }
    }
}
