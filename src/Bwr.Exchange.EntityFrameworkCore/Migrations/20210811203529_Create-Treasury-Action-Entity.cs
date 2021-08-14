using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bwr.Exchange.Migrations
{
    public partial class CreateTreasuryActionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCashFlow_Transaction_TransactionId",
                table: "ClientCashFlow");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCashFlow_AbpUsers_UserId",
                table: "ClientCashFlow");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCashFlow_Transaction_TransactionId",
                table: "CompanyCashFlow");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCashFlow_AbpUsers_UserId",
                table: "CompanyCashFlow");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryCashFlow_Transaction_TransactionId",
                table: "TreasuryCashFlow");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TreasuryCashFlow",
                table: "TreasuryCashFlow");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryCashFlow_TransactionId",
                table: "TreasuryCashFlow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyCashFlow",
                table: "CompanyCashFlow");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCashFlow_TransactionId",
                table: "CompanyCashFlow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCashFlow",
                table: "ClientCashFlow");

            migrationBuilder.DropIndex(
                name: "IX_ClientCashFlow_TransactionId",
                table: "ClientCashFlow");

            migrationBuilder.DropColumn(
                name: "ReceivesdAmount",
                table: "OutgoingTransfers");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "TreasuryCashFlow");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "CompanyCashFlow");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "ClientCashFlow");

            migrationBuilder.RenameTable(
                name: "TreasuryCashFlow",
                newName: "TreasuryCashFlows");

            migrationBuilder.RenameTable(
                name: "CompanyCashFlow",
                newName: "CompanyCashFlows");

            migrationBuilder.RenameTable(
                name: "ClientCashFlow",
                newName: "ClientCashFlows");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCashFlow_UserId",
                table: "CompanyCashFlows",
                newName: "IX_CompanyCashFlows_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCashFlow_UserId",
                table: "ClientCashFlows",
                newName: "IX_ClientCashFlows_UserId");

            migrationBuilder.AddColumn<double>(
                name: "ReceivedAmount",
                table: "OutgoingTransfers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TreasuryCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "TreasuryCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreasuryBalanceId",
                table: "TreasuryCashFlows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TreasuryCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "CompanyCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CompanyCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "ClientCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ClientCashFlows",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TreasuryCashFlows",
                table: "TreasuryCashFlows",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyCashFlows",
                table: "CompanyCashFlows",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCashFlows",
                table: "ClientCashFlows",
                column: "Id");

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

            migrationBuilder.CreateTable(
                name: "TreasuryActions",
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
                    ActionType = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    MainAccount = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: true),
                    ToCompanyId = table.Column<int>(nullable: true),
                    ToClientId = table.Column<int>(nullable: true),
                    FromCompanyId = table.Column<int>(nullable: true),
                    FromClientId = table.Column<int>(nullable: true),
                    TreasuryId = table.Column<int>(nullable: true),
                    ExpenseId = table.Column<int>(nullable: true),
                    IncomeId = table.Column<int>(nullable: true),
                    IncomeTransferDetailId = table.Column<int>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    InstrumentNo = table.Column<string>(nullable: true),
                    IdentificationNumber = table.Column<string>(nullable: true),
                    Issuer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreasuryActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreasuryActions_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreasuryActions_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreasuryActions_Clients_FromClientId",
                        column: x => x.FromClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreasuryActions_Companies_FromCompanyId",
                        column: x => x.FromCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreasuryActions_Incomes_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "Incomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreasuryActions_IncomeTransferDetail_IncomeTransferDetailId",
                        column: x => x.IncomeTransferDetailId,
                        principalTable: "IncomeTransferDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreasuryActions_Clients_ToClientId",
                        column: x => x.ToClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreasuryActions_Companies_ToCompanyId",
                        column: x => x.ToCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreasuryActions_Treasuries_TreasuryId",
                        column: x => x.TreasuryId,
                        principalTable: "Treasuries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryCashFlows_TreasuryBalanceId",
                table: "TreasuryCashFlows",
                column: "TreasuryBalanceId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_CurrencyId",
                table: "TreasuryActions",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_ExpenseId",
                table: "TreasuryActions",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_FromClientId",
                table: "TreasuryActions",
                column: "FromClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_FromCompanyId",
                table: "TreasuryActions",
                column: "FromCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_IncomeId",
                table: "TreasuryActions",
                column: "IncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_IncomeTransferDetailId",
                table: "TreasuryActions",
                column: "IncomeTransferDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_ToClientId",
                table: "TreasuryActions",
                column: "ToClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_ToCompanyId",
                table: "TreasuryActions",
                column: "ToCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_TreasuryId",
                table: "TreasuryActions",
                column: "TreasuryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCashFlows_AbpUsers_UserId",
                table: "ClientCashFlows",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCashFlows_AbpUsers_UserId",
                table: "CompanyCashFlows",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryCashFlows_TreasuryBalances_TreasuryBalanceId",
                table: "TreasuryCashFlows",
                column: "TreasuryBalanceId",
                principalTable: "TreasuryBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCashFlows_AbpUsers_UserId",
                table: "ClientCashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCashFlows_AbpUsers_UserId",
                table: "CompanyCashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryCashFlows_TreasuryBalances_TreasuryBalanceId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropTable(
                name: "TreasuryActions");

            migrationBuilder.DropTable(
                name: "IncomeTransferDetail");

            migrationBuilder.DropTable(
                name: "IncomeTransfer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TreasuryCashFlows",
                table: "TreasuryCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryCashFlows_TreasuryBalanceId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyCashFlows",
                table: "CompanyCashFlows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCashFlows",
                table: "ClientCashFlows");

            migrationBuilder.DropColumn(
                name: "ReceivedAmount",
                table: "OutgoingTransfers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "TreasuryBalanceId",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "TreasuryCashFlows");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "CompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "ClientCashFlows");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ClientCashFlows");

            migrationBuilder.RenameTable(
                name: "TreasuryCashFlows",
                newName: "TreasuryCashFlow");

            migrationBuilder.RenameTable(
                name: "CompanyCashFlows",
                newName: "CompanyCashFlow");

            migrationBuilder.RenameTable(
                name: "ClientCashFlows",
                newName: "ClientCashFlow");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCashFlows_UserId",
                table: "CompanyCashFlow",
                newName: "IX_CompanyCashFlow_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCashFlows_UserId",
                table: "ClientCashFlow",
                newName: "IX_ClientCashFlow_UserId");

            migrationBuilder.AddColumn<double>(
                name: "ReceivesdAmount",
                table: "OutgoingTransfers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "TreasuryCashFlow",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "CompanyCashFlow",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "ClientCashFlow",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TreasuryCashFlow",
                table: "TreasuryCashFlow",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyCashFlow",
                table: "CompanyCashFlow",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCashFlow",
                table: "ClientCashFlow",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryCashFlow_TransactionId",
                table: "TreasuryCashFlow",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCashFlow_TransactionId",
                table: "CompanyCashFlow",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCashFlow_TransactionId",
                table: "ClientCashFlow",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCashFlow_Transaction_TransactionId",
                table: "ClientCashFlow",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCashFlow_AbpUsers_UserId",
                table: "ClientCashFlow",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCashFlow_Transaction_TransactionId",
                table: "CompanyCashFlow",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCashFlow_AbpUsers_UserId",
                table: "CompanyCashFlow",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryCashFlow_Transaction_TransactionId",
                table: "TreasuryCashFlow",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
