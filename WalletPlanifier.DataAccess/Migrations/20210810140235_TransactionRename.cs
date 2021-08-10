using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletPlanifier.DataAccess.Migrations
{
    public partial class TransactionRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriptiom",
                table: "Transaction");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Transaction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Transaction");

            migrationBuilder.AddColumn<string>(
                name: "Descriptiom",
                table: "Transaction",
                type: "text",
                nullable: true);
        }
    }
}
