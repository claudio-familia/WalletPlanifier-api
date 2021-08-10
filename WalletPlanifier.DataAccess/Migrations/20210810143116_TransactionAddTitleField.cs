using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletPlanifier.DataAccess.Migrations
{
    public partial class TransactionAddTitleField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Transaction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Transaction");
        }
    }
}
