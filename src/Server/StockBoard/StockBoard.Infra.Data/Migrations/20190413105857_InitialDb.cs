using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockBoard.Infra.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brokers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brokers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BrokerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Brokers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Brokers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StockId = table.Column<Guid>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Commission = table.Column<double>(nullable: false),
                    BrokerId = table.Column<Guid>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Brokers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Brokers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("01b901f8-9890-4529-9667-00a0e3ee03bf"), "Vianet", 13.5 },
                    { new Guid("26b901f8-9890-4529-9667-00a0e3ee03bf"), "MeetMe", 26.699999999999999 },
                    { new Guid("25b901f8-9890-4529-9667-00a0e3ee03bf"), "InterNAP", 22.699999999999999 },
                    { new Guid("24b901f8-9890-4529-9667-00a0e3ee03bf"), "Genesis", 17.0 },
                    { new Guid("23b901f8-9890-4529-9667-00a0e3ee03bf"), "FlashZero", 17.699999999999999 },
                    { new Guid("22b901f8-9890-4529-9667-00a0e3ee03bf"), "Epazz", 13.699999999999999 },
                    { new Guid("21b901f8-9890-4529-9667-00a0e3ee03bf"), "Envestnet", 12.699999999999999 },
                    { new Guid("20b901f8-9890-4529-9667-00a0e3ee03bf"), "ENDEXX", 20.699999999999999 },
                    { new Guid("19b901f8-9890-4529-9667-00a0e3ee03bf"), "Eastern", 31.699999999999999 },
                    { new Guid("18b901f8-9890-4529-9667-00a0e3ee03bf"), "EarthLink", 18.199999999999999 },
                    { new Guid("17b901f8-9890-4529-9667-00a0e3ee03bf"), "CrowdGather", 7.2000000000000002 },
                    { new Guid("16b901f8-9890-4529-9667-00a0e3ee03bf"), "Crexendo", 14.1 },
                    { new Guid("15b901f8-9890-4529-9667-00a0e3ee03bf"), "Cogent", 6.7000000000000002 },
                    { new Guid("14b901f8-9890-4529-9667-00a0e3ee03bf"), "Cnova", 19.699999999999999 },
                    { new Guid("13b901f8-9890-4529-9667-00a0e3ee03bf"), "ChitrChatr", 11.699999999999999 },
                    { new Guid("12b901f8-9890-4529-9667-00a0e3ee03bf"), "ADR", 43.5 },
                    { new Guid("11b901f8-9890-4529-9667-00a0e3ee03bf"), "ChinaCache", 9.0999999999999996 },
                    { new Guid("10b901f8-9890-4529-9667-00a0e3ee03bf"), "China Finance", 4.4000000000000004 },
                    { new Guid("92b901f8-9890-4529-9667-00a0e3ee03bf"), "Carbonite", 51.5 },
                    { new Guid("82b901f8-9890-4529-9667-00a0e3ee03bf"), "Brainybrawn", 13.9 },
                    { new Guid("72b901f8-9890-4529-9667-00a0e3ee03bf"), "Boingo", 19.399999999999999 },
                    { new Guid("62b901f8-9890-4529-9667-00a0e3ee03bf"), "Blucora", 30.300000000000001 },
                    { new Guid("52b901f8-9890-4529-9667-00a0e3ee03bf"), "Blinkx", 32.5 },
                    { new Guid("42b901f8-9890-4529-9667-00a0e3ee03bf"), "Baidu", 61.5 },
                    { new Guid("38b901f8-9890-4529-9667-00a0e3ee03bf"), "Akamai", 54.5 },
                    { new Guid("29b901f8-9890-4529-9667-00a0e3ee03bf"), "Agritek", 5.5 },
                    { new Guid("27b901f8-9890-4529-9667-00a0e3ee03bf"), "Netease", 25.699999999999999 },
                    { new Guid("28b901f8-9890-4529-9667-00a0e3ee03bf"), "Qihoo", 29.699999999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BrokerId",
                table: "Orders",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PersonId",
                table: "Orders",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BrokerId",
                table: "Persons",
                column: "BrokerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Brokers");
        }
    }
}
