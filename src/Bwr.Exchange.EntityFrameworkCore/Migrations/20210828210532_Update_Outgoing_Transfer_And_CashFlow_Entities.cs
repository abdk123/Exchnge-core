using Microsoft.EntityFrameworkCore.Migrations;

namespace Bwr.Exchange.Migrations
{
    public partial class Update_Outgoing_Transfer_And_CashFlow_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Beneficiary",
                table: "TreasuryCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Commission",
                table: "TreasuryCashFlows",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "TreasuryCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "TreasuryCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreasuryId",
                table: "OutgoingTransfers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Beneficiary",
                table: "CompanyCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "CompanyCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "CompanyCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Beneficiary",
                table: "ClientCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "ClientCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "ClientCashFlows",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_TreasuryId",
                table: "OutgoingTransfers",
                column: "TreasuryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutgoingTransfers_Treasuries_TreasuryId",
                table: "OutgoingTransfers",
                column: "TreasuryId",
                principalTable: "Treasuries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutgoingTransfers_Treasuries_TreasuryId",
                table: "OutgoingTransfers");

            migrationBuilder.DropIndex(
                name: "IX_OutgoingTransfers_TreasuryId",
                table: "OutgoingTransfers");

            migrationBuilder.DropColumn(
                name: "Beneficiary",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "Commission",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "TreasuryId",
                table: "OutgoingTransfers");

            migrationBuilder.DropColumn(
                name: "Beneficiary",
                table: "CompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "CompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "CompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "Beneficiary",
                table: "ClientCashFlows");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "ClientCashFlows");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "ClientCashFlows");
        }
    }
}
