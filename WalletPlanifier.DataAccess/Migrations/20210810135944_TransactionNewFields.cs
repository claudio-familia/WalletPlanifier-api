using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletPlanifier.DataAccess.Migrations
{
    public partial class TransactionNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descriptiom",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalWalletValue",
                table: "Transaction",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OriginWalletValue",
                table: "Transaction",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriptiom",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "FinalWalletValue",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "OriginWalletValue",
                table: "Transaction");
        }
    }
}
