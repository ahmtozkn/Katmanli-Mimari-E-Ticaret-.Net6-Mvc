using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstShop.Data.Migrations
{
    public partial class mig62 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "PaymentMethods",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 9, 16, 8, 37, 30, 50, DateTimeKind.Local).AddTicks(5550), "CfDJ8PCQTJZqofVAoaMldghIe9t7fRi5Utnv0CWOc_LUdPkiI_uEswUK1CTd09B40bGASCCZjroSrVAsoZju22WEYxxY6BGYJIcsVIY1SRIW7PorqpAsH_bZRY0gbDnHU2DQjQ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CardNumber",
                table: "PaymentMethods",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 9, 15, 8, 14, 52, 729, DateTimeKind.Local).AddTicks(974), "CfDJ8PCQTJZqofVAoaMldghIe9sHbfdCOFu5u5RTYNTEWH-yFuMe5Y1t20XwMbT_jlGF_vLyfJzRWaGPVjTzrR_tTfBOyFUZjwu_XwmbE75Ken2kIRiHQrNuMLiesMEk7VEPKg" });
        }
    }
}
