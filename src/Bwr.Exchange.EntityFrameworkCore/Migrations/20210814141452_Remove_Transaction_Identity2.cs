using Microsoft.EntityFrameworkCore.Migrations;

namespace Bwr.Exchange.Migrations
{
    public partial class Remove_Transaction_Identity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCashFlows_Transaction_TransactionId",
                table: "ClientCashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCashFlows_Transaction_TransactionId",
                table: "CompanyCashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryCashFlows_Transaction_TransactionId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryCashFlows_TransactionId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCashFlows_TransactionId",
                table: "CompanyCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_ClientCashFlows_TransactionId",
                table: "ClientCashFlows");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "CompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "ClientCashFlows");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "TreasuryCashFlows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "CompanyCashFlows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "ClientCashFlows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryCashFlows_TransactionId",
                table: "TreasuryCashFlows",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCashFlows_TransactionId",
                table: "CompanyCashFlows",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCashFlows_TransactionId",
                table: "ClientCashFlows",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCashFlows_Transaction_TransactionId",
                table: "ClientCashFlows",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCashFlows_Transaction_TransactionId",
                table: "CompanyCashFlows",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryCashFlows_Transaction_TransactionId",
                table: "TreasuryCashFlows",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
