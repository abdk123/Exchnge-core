using Microsoft.EntityFrameworkCore.Migrations;

namespace Bwr.Exchange.Migrations
{
    public partial class Recreate_Transaction_Value_Object2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "TreasuryCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "TreasuryCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "CompanyCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "CompanyCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "ClientCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "ClientCashFlows",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => new { x.TransactionId, x.TransactionType });
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryCashFlows_TransactionId_TransactionType",
                table: "TreasuryCashFlows",
                columns: new[] { "TransactionId", "TransactionType" });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCashFlows_TransactionId_TransactionType",
                table: "CompanyCashFlows",
                columns: new[] { "TransactionId", "TransactionType" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCashFlows_TransactionId_TransactionType",
                table: "ClientCashFlows",
                columns: new[] { "TransactionId", "TransactionType" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCashFlows_Transaction_TransactionId_TransactionType",
                table: "ClientCashFlows",
                columns: new[] { "TransactionId", "TransactionType" },
                principalTable: "Transaction",
                principalColumns: new[] { "TransactionId", "TransactionType" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCashFlows_Transaction_TransactionId_TransactionType",
                table: "CompanyCashFlows",
                columns: new[] { "TransactionId", "TransactionType" },
                principalTable: "Transaction",
                principalColumns: new[] { "TransactionId", "TransactionType" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryCashFlows_Transaction_TransactionId_TransactionType",
                table: "TreasuryCashFlows",
                columns: new[] { "TransactionId", "TransactionType" },
                principalTable: "Transaction",
                principalColumns: new[] { "TransactionId", "TransactionType" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCashFlows_Transaction_TransactionId_TransactionType",
                table: "ClientCashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCashFlows_Transaction_TransactionId_TransactionType",
                table: "CompanyCashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryCashFlows_Transaction_TransactionId_TransactionType",
                table: "TreasuryCashFlows");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryCashFlows_TransactionId_TransactionType",
                table: "TreasuryCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCashFlows_TransactionId_TransactionType",
                table: "CompanyCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_ClientCashFlows_TransactionId_TransactionType",
                table: "ClientCashFlows");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "CompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "CompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "ClientCashFlows");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "ClientCashFlows");
        }
    }
}
