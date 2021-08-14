using Microsoft.EntityFrameworkCore.Migrations;

namespace Bwr.Exchange.Migrations
{
    public partial class Update_Treasury_Cash_Flow_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryCashFlows_TreasuryBalances_TreasuryBalanceId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryCashFlows_TreasuryBalanceId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "TreasuryBalanceId",
                table: "TreasuryCashFlows");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "TreasuryCashFlows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TreasuryId",
                table: "TreasuryCashFlows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryCashFlows_CurrencyId",
                table: "TreasuryCashFlows",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryCashFlows_TreasuryId",
                table: "TreasuryCashFlows",
                column: "TreasuryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryCashFlows_Currencies_CurrencyId",
                table: "TreasuryCashFlows",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryCashFlows_Treasuries_TreasuryId",
                table: "TreasuryCashFlows",
                column: "TreasuryId",
                principalTable: "Treasuries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryCashFlows_Currencies_CurrencyId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryCashFlows_Treasuries_TreasuryId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryCashFlows_CurrencyId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryCashFlows_TreasuryId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "TreasuryId",
                table: "TreasuryCashFlows");

            migrationBuilder.AddColumn<int>(
                name: "TreasuryBalanceId",
                table: "TreasuryCashFlows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryCashFlows_TreasuryBalanceId",
                table: "TreasuryCashFlows",
                column: "TreasuryBalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryCashFlows_TreasuryBalances_TreasuryBalanceId",
                table: "TreasuryCashFlows",
                column: "TreasuryBalanceId",
                principalTable: "TreasuryBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
