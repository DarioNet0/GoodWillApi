using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodWill.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CampaignMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BoletoPayment",
                table: "Campaigns",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CreditCardPayment",
                table: "Campaigns",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PixPayment",
                table: "Campaigns",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoletoPayment",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CreditCardPayment",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "PixPayment",
                table: "Campaigns");
        }
    }
}
