﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockBoard.Infra.Data.Context;

namespace StockBoard.Infra.Data.Migrations
{
    [DbContext(typeof(StockBoardContext))]
    partial class StockBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockBoard.Domain.Models.Broker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Brokers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11a111a1-9890-4529-9667-00a0e3ee03bf"),
                            Name = "My Broker"
                        });
                });

            modelBuilder.Entity("StockBoard.Domain.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<Guid?>("BrokerId");

                    b.Property<double>("Commission");

                    b.Property<Guid?>("PersonId");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<Guid>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("BrokerId");

                    b.HasIndex("PersonId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("StockBoard.Domain.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<Guid?>("BrokerId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BrokerId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22a111a1-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Tarek"
                        },
                        new
                        {
                            Id = new Guid("33a111a1-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Hady"
                        });
                });

            modelBuilder.Entity("StockBoard.Domain.Models.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("01b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Vianet",
                            Price = 13.5
                        },
                        new
                        {
                            Id = new Guid("29b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Agritek",
                            Price = 5.5
                        },
                        new
                        {
                            Id = new Guid("38b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Akamai",
                            Price = 54.5
                        },
                        new
                        {
                            Id = new Guid("42b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Baidu",
                            Price = 61.5
                        },
                        new
                        {
                            Id = new Guid("52b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Blinkx",
                            Price = 32.5
                        },
                        new
                        {
                            Id = new Guid("62b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Blucora",
                            Price = 30.300000000000001
                        },
                        new
                        {
                            Id = new Guid("72b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Boingo",
                            Price = 19.399999999999999
                        },
                        new
                        {
                            Id = new Guid("82b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Brainybrawn",
                            Price = 13.9
                        },
                        new
                        {
                            Id = new Guid("92b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Carbonite",
                            Price = 51.5
                        },
                        new
                        {
                            Id = new Guid("10b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "China Finance",
                            Price = 4.4000000000000004
                        },
                        new
                        {
                            Id = new Guid("11b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "ChinaCache",
                            Price = 9.0999999999999996
                        },
                        new
                        {
                            Id = new Guid("12b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "ADR",
                            Price = 43.5
                        },
                        new
                        {
                            Id = new Guid("13b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "ChitrChatr",
                            Price = 11.699999999999999
                        },
                        new
                        {
                            Id = new Guid("14b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Cnova",
                            Price = 19.699999999999999
                        },
                        new
                        {
                            Id = new Guid("15b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Cogent",
                            Price = 6.7000000000000002
                        },
                        new
                        {
                            Id = new Guid("16b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Crexendo",
                            Price = 14.1
                        },
                        new
                        {
                            Id = new Guid("17b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "CrowdGather",
                            Price = 7.2000000000000002
                        },
                        new
                        {
                            Id = new Guid("18b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "EarthLink",
                            Price = 18.199999999999999
                        },
                        new
                        {
                            Id = new Guid("19b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Eastern",
                            Price = 31.699999999999999
                        },
                        new
                        {
                            Id = new Guid("20b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "ENDEXX",
                            Price = 20.699999999999999
                        },
                        new
                        {
                            Id = new Guid("21b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Envestnet",
                            Price = 12.699999999999999
                        },
                        new
                        {
                            Id = new Guid("22b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Epazz",
                            Price = 13.699999999999999
                        },
                        new
                        {
                            Id = new Guid("23b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "FlashZero",
                            Price = 17.699999999999999
                        },
                        new
                        {
                            Id = new Guid("24b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Genesis",
                            Price = 17.0
                        },
                        new
                        {
                            Id = new Guid("25b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "InterNAP",
                            Price = 22.699999999999999
                        },
                        new
                        {
                            Id = new Guid("26b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "MeetMe",
                            Price = 26.699999999999999
                        },
                        new
                        {
                            Id = new Guid("27b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Netease",
                            Price = 25.699999999999999
                        },
                        new
                        {
                            Id = new Guid("28b901f8-9890-4529-9667-00a0e3ee03bf"),
                            Name = "Qihoo",
                            Price = 29.699999999999999
                        });
                });

            modelBuilder.Entity("StockBoard.Domain.Models.Order", b =>
                {
                    b.HasOne("StockBoard.Domain.Models.Broker")
                        .WithMany("Orders")
                        .HasForeignKey("BrokerId");

                    b.HasOne("StockBoard.Domain.Models.Person")
                        .WithMany("Orders")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("StockBoard.Domain.Models.Person", b =>
                {
                    b.HasOne("StockBoard.Domain.Models.Broker")
                        .WithMany("Persons")
                        .HasForeignKey("BrokerId");
                });
#pragma warning restore 612, 618
        }
    }
}
