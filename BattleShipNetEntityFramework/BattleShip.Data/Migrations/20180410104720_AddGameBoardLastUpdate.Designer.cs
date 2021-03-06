﻿// <auto-generated />
using BattleShip.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BattleShip.Data.Migrations
{
    [DbContext(typeof(BattleShipContext))]
    [Migration("20180410104720_AddGameBoardLastUpdate")]
    partial class AddGameBoardLastUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BattleShip.Domain.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BattleShip.Domain.Boat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoatTypeId");

                    b.Property<int?>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("BoatTypeId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Boats");
                });

            modelBuilder.Entity("BattleShip.Domain.BoatHit", b =>
                {
                    b.Property<int>("BoatId");

                    b.Property<int>("PositionId");

                    b.HasKey("BoatId", "PositionId");

                    b.HasIndex("PositionId");

                    b.ToTable("BoatHits");
                });

            modelBuilder.Entity("BattleShip.Domain.BoatPosition", b =>
                {
                    b.Property<int>("BoatId");

                    b.Property<int>("PositionId");

                    b.HasKey("BoatId", "PositionId");

                    b.HasIndex("PositionId");

                    b.ToTable("BoatPositions");
                });

            modelBuilder.Entity("BattleShip.Domain.BoatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Size");

                    b.HasKey("Id");

                    b.ToTable("BoatTypes");
                });

            modelBuilder.Entity("BattleShip.Domain.GameBoard", b =>
                {
                    b.Property<string>("GameKey")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdate");

                    b.Property<bool>("Private");

                    b.Property<int>("TurnPlayerId");

                    b.HasKey("GameKey");

                    b.HasIndex("TurnPlayerId");

                    b.ToTable("GameBoards");
                });

            modelBuilder.Entity("BattleShip.Domain.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<string>("GameBoardGameKey");

                    b.Property<string>("GameBoardKey");

                    b.Property<bool>("HaveSeenEndScreen");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("GameBoardGameKey");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BattleShip.Domain.PlayerBoat", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("BoatId");

                    b.HasKey("PlayerId", "BoatId");

                    b.HasIndex("BoatId");

                    b.ToTable("PlayerBoats");
                });

            modelBuilder.Entity("BattleShip.Domain.PlayerHit", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("PositionId");

                    b.HasKey("PlayerId", "PositionId");

                    b.HasIndex("PositionId");

                    b.ToTable("PlayerHits");
                });

            modelBuilder.Entity("BattleShip.Domain.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.HasKey("Id");

                    b.HasIndex("X", "Y")
                        .IsUnique();

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("BattleShip.Domain.Boat", b =>
                {
                    b.HasOne("BattleShip.Domain.BoatType", "Type")
                        .WithMany()
                        .HasForeignKey("BoatTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BattleShip.Domain.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("BattleShip.Domain.BoatHit", b =>
                {
                    b.HasOne("BattleShip.Domain.Boat", "Boat")
                        .WithMany("Hits")
                        .HasForeignKey("BoatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BattleShip.Domain.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BattleShip.Domain.BoatPosition", b =>
                {
                    b.HasOne("BattleShip.Domain.Boat", "Boat")
                        .WithMany("Positions")
                        .HasForeignKey("BoatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BattleShip.Domain.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BattleShip.Domain.GameBoard", b =>
                {
                    b.HasOne("BattleShip.Domain.Player", "TurnPlayer")
                        .WithMany()
                        .HasForeignKey("TurnPlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BattleShip.Domain.Player", b =>
                {
                    b.HasOne("BattleShip.Domain.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BattleShip.Domain.GameBoard", "GameBoard")
                        .WithMany("Players")
                        .HasForeignKey("GameBoardGameKey");
                });

            modelBuilder.Entity("BattleShip.Domain.PlayerBoat", b =>
                {
                    b.HasOne("BattleShip.Domain.Boat", "Boat")
                        .WithMany()
                        .HasForeignKey("BoatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BattleShip.Domain.Player", "Player")
                        .WithMany("Boats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BattleShip.Domain.PlayerHit", b =>
                {
                    b.HasOne("BattleShip.Domain.Player", "Player")
                        .WithMany("AlreadyHitPositions")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BattleShip.Domain.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
