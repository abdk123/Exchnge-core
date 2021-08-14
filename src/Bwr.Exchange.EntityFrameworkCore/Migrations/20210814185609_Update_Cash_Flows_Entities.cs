using Microsoft.EntityFrameworkCore.Migrations;

namespace Bwr.Exchange.Migrations
{
    public partial class Update_Cash_Flows_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_TreasuryCashFlows_TransactionId_TransactionType",
                table: "TreasuryCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCashFlows_TransactionId_TransactionType",
                table: "CompanyCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_ClientCashFlows_TransactionId_TransactionType",
                table: "ClientCashFlows");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionType",
                table: "TreasuryCashFlows",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "TreasuryCashFlows",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstrumentNo",
                table: "TreasuryCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Matched",
                table: "TreasuryCashFlows",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Shaded",
                table: "TreasuryCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "TreasuryCashFlows",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransactionType",
                table: "CompanyCashFlows",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "CompanyCashFlows",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "CompanyCashFlows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TransactionType",
                table: "ClientCashFlows",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "ClientCashFlows",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryCashFlows_UserId",
                table: "TreasuryCashFlows",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCashFlows_CompanyId",
                table: "CompanyCashFlows",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCashFlows_Companies_CompanyId",
                table: "CompanyCashFlows",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryCashFlows_AbpUsers_UserId",
                table: "TreasuryCashFlows",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCashFlows_Companies_CompanyId",
                table: "CompanyCashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryCashFlows_AbpUsers_UserId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryCashFlows_UserId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCashFlows_CompanyId",
                table: "CompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "InstrumentNo",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "Matched",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "Shaded",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CompanyCashFlows");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionType",
                table: "TreasuryCashFlows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "TreasuryCashFlows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TransactionType",
                table: "CompanyCashFlows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "CompanyCashFlows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TransactionType",
                table: "ClientCashFlows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "ClientCashFlows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
