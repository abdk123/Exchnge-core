using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bwr.Exchange.Migrations
{
    public partial class Reupdate_Treasury_Action_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryActions_OutgoingTransfers_OutgoingTransferId",
                table: "TreasuryActions");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryActions_OutgoingTransferId",
                table: "TreasuryActions");

            migrationBuilder.DropColumn(
                name: "OutgoingTransferId",
                table: "TreasuryActions");

            migrationBuilder.AddColumn<int>(
                name: "IncomeTransferDetailId",
                table: "TreasuryActions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IncomeTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeTransfer_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncomeTransferDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: false),
                    BeneficiaryId = table.Column<int>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    PaymentType = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Commission = table.Column<double>(nullable: false),
                    CompanyCommission = table.Column<double>(nullable: false),
                    ClientCommission = table.Column<double>(nullable: false),
                    ToCompanyId = table.Column<int>(nullable: true),
                    ToClientId = table.Column<int>(nullable: true),
                    IncomeTransferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeTransferDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeTransferDetail_Customers_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncomeTransferDetail_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomeTransferDetail_IncomeTransfer_IncomeTransferId",
                        column: x => x.IncomeTransferId,
                        principalTable: "IncomeTransfer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomeTransferDetail_Customers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncomeTransferDetail_Clients_ToClientId",
                        column: x => x.ToClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncomeTransferDetail_Companies_ToCompanyId",
                        column: x => x.ToCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_IncomeTransferDetailId",
                table: "TreasuryActions",
                column: "IncomeTransferDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTransfer_CompanyId",
                table: "IncomeTransfer",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTransferDetail_BeneficiaryId",
                table: "IncomeTransferDetail",
                column: "BeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTransferDetail_CurrencyId",
                table: "IncomeTransferDetail",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTransferDetail_IncomeTransferId",
                table: "IncomeTransferDetail",
                column: "IncomeTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTransferDetail_SenderId",
                table: "IncomeTransferDetail",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTransferDetail_ToClientId",
                table: "IncomeTransferDetail",
                column: "ToClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTransferDetail_ToCompanyId",
                table: "IncomeTransferDetail",
                column: "ToCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryActions_IncomeTransferDetail_IncomeTransferDetailId",
                table: "TreasuryActions",
                column: "IncomeTransferDetailId",
                principalTable: "IncomeTransferDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryActions_IncomeTransferDetail_IncomeTransferDetailId",
                table: "TreasuryActions");

            migrationBuilder.DropTable(
                name: "IncomeTransferDetail");

            migrationBuilder.DropTable(
                name: "IncomeTransfer");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryActions_IncomeTransferDetailId",
                table: "TreasuryActions");

            migrationBuilder.DropColumn(
                name: "IncomeTransferDetailId",
                table: "TreasuryActions");

            migrationBuilder.AddColumn<int>(
                name: "OutgoingTransferId",
                table: "TreasuryActions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_OutgoingTransferId",
                table: "TreasuryActions",
                column: "OutgoingTransferId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryActions_OutgoingTransfers_OutgoingTransferId",
                table: "TreasuryActions",
                column: "OutgoingTransferId",
                principalTable: "OutgoingTransfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
