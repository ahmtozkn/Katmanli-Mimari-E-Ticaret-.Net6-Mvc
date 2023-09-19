using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstShop.Data.Migrations
{
    public partial class mig321 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "IsDeleted", "LastName", "ModifiedDate", "Password", "UserType" },
                values: new object[] { 7, new DateTime(2023, 9, 15, 7, 41, 23, 398, DateTimeKind.Local).AddTicks(3435), "Admin@email.com", "Admin", false, "Admin", null, "CfDJ8PCQTJZqofVAoaMldghIe9s11U12t_vw0t81uTi21lwgUvZqD1HgIhGGbPhphH9kRElYU5s3bey-oJ_eGRFGRyF0XUHeJbUMj8b67HWVdpuc0QKjfTljWLkesKR4P37bAw", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
