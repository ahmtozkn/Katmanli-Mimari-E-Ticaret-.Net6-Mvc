using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstShop.Data.Migrations
{
    public partial class mig452 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "PaymentMethods");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethodName",
                table: "PaymentMethods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ExpirationMonth",
                table: "PaymentMethods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpirationYear",
                table: "PaymentMethods",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 9, 15, 8, 14, 52, 729, DateTimeKind.Local).AddTicks(974), "CfDJ8PCQTJZqofVAoaMldghIe9sHbfdCOFu5u5RTYNTEWH-yFuMe5Y1t20XwMbT_jlGF_vLyfJzRWaGPVjTzrR_tTfBOyFUZjwu_XwmbE75Ken2kIRiHQrNuMLiesMEk7VEPKg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationMonth",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "ExpirationYear",
                table: "PaymentMethods");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethodName",
                table: "PaymentMethods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "PaymentMethods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 9, 15, 7, 41, 23, 398, DateTimeKind.Local).AddTicks(3435), "CfDJ8PCQTJZqofVAoaMldghIe9s11U12t_vw0t81uTi21lwgUvZqD1HgIhGGbPhphH9kRElYU5s3bey-oJ_eGRFGRyF0XUHeJbUMj8b67HWVdpuc0QKjfTljWLkesKR4P37bAw" });
        }
    }
}
