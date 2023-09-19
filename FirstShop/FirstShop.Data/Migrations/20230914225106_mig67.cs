using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstShop.Data.Migrations
{
    public partial class mig67 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartNumber",
                table: "PaymentMethods",
                newName: "CardNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "PaymentMethods",
                newName: "CartNumber");
        }
    }
}
