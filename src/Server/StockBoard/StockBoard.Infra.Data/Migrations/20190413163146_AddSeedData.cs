using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockBoard.Infra.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brokers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("11a111a1-9890-4529-9667-00a0e3ee03bf"), "My Broker" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BrokerId", "Name" },
                values: new object[] { new Guid("22a111a1-9890-4529-9667-00a0e3ee03bf"), null, "Tarek" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BrokerId", "Name" },
                values: new object[] { new Guid("33a111a1-9890-4529-9667-00a0e3ee03bf"), null, "Hady" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: new Guid("11a111a1-9890-4529-9667-00a0e3ee03bf"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("22a111a1-9890-4529-9667-00a0e3ee03bf"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("33a111a1-9890-4529-9667-00a0e3ee03bf"));
        }
    }
}
