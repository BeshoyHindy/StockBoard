using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StockBoard.Domain.Models;

namespace StockBoard.Infra.Data.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasData(
                new Stock(
                    id: new Guid("01b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Vianet",
                    price: 13.5),
                new Stock(
                    id: new Guid("29b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Agritek",
                    price: 5.5),
                new Stock(
                    id: new Guid("38b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Akamai",
                    price: 54.5),
                new Stock(
                    id: new Guid("42b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Baidu",
                    price: 61.5),
                new Stock(
                    id: new Guid("52b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Blinkx",
                    price: 32.5),
                new Stock(
                    id: new Guid("62b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Blucora",
                    price: 30.3),
                new Stock(
                    id: new Guid("72b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Boingo",
                    price: 19.4),
                new Stock(
                    id: new Guid("82b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Brainybrawn",
                    price: 13.9),
                new Stock(
                    id: new Guid("92b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Carbonite",
                    price: 51.5),
                new Stock(
                    id: new Guid("10b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "China Finance",
                    price: 4.4),
                new Stock(
                    id: new Guid("11b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "ChinaCache",
                    price: 9.1),
                new Stock(
                    id: new Guid("12b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "ADR",
                    price: 43.5),
                new Stock(
                    id: new Guid("13b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "ChitrChatr",
                    price: 11.7),
                new Stock(
                    id: new Guid("14b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Cnova",
                    price: 19.7),
                new Stock(
                    id: new Guid("15b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Cogent",
                    price: 6.7),
                new Stock(
                    id: new Guid("16b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Crexendo",
                    price: 14.1),
                new Stock(
                    id: new Guid("17b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "CrowdGather",
                    price: 7.2),
                new Stock(
                    id: new Guid("18b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "EarthLink",
                    price: 18.2),
                new Stock(
                    id: new Guid("19b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Eastern",
                    price: 31.7),
                new Stock(
                    id: new Guid("20b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "ENDEXX",
                    price: 20.7),
                new Stock(
                    id: new Guid("21b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Envestnet",
                    price: 12.7),
                new Stock(
                    id: new Guid("22b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Epazz",
                    price: 13.7),
                new Stock(
                    id: new Guid("23b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "FlashZero",
                    price: 17.7),
                new Stock(
                    id: new Guid("24b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Genesis",
                    price: 17),
                new Stock(
                    id: new Guid("25b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "InterNAP",
                    price: 22.7),
                new Stock(
                    id: new Guid("26b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "MeetMe",
                    price: 26.7),
                new Stock(
                    id: new Guid("27b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Netease",
                    price: 25.7),
                new Stock(
                    id: new Guid("28b901f8-9890-4529-9667-00a0e3ee03bf"),
                    name: "Qihoo",
                    price: 29.7)

            );

            modelBuilder.Entity<Broker>().HasData(
                new Broker(new Guid("11a111a1-9890-4529-9667-00a0e3ee03bf"), "My Broker")
                    );

            modelBuilder.Entity<Person>().HasData(
                new Person(new Guid("22a111a1-9890-4529-9667-00a0e3ee03bf"), "Tarek"),
                new Person(new Guid("33a111a1-9890-4529-9667-00a0e3ee03bf"), "Hady")
                    );

        }
    }
}