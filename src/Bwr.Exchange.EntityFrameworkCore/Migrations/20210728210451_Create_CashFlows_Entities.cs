using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bwr.Exchange.Migrations
{
    public partial class Create_CashFlows_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
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
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "OutgoingTransfers",
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
                    ReceivingCompanyId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    SendingCompanyId = table.Column<int>(nullable: true),
                    SendingClientId = table.Column<int>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    BeneficiaryId = table.Column<int>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Commission = table.Column<double>(nullable: false),
                    ClientCommission = table.Column<double>(nullable: false),
                    ReceivedAmount = table.Column<double>(nullable: false),
                    InstrumentNo = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutgoingTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutgoingTransfers_Customers_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutgoingTransfers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutgoingTransfers_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutgoingTransfers_Companies_ReceivingCompanyId",
                        column: x => x.ReceivingCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutgoingTransfers_Customers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutgoingTransfers_Clients_SendingClientId",
                        column: x => x.SendingClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutgoingTransfers_Companies_SendingCompanyId",
                        column: x => x.SendingCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientCashFlow",
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
                    Amount = table.Column<double>(nullable: false),
                    CurrentBalance = table.Column<double>(nullable: false),
                    TransactionId = table.Column<int>(nullable: true),
                    Matched = table.Column<bool>(nullable: false),
                    Shaded = table.Column<bool>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Commission = table.Column<double>(nullable: false),
                    ClientCommission = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCashFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCashFlow_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientCashFlow_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCashFlow",
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
                    Amount = table.Column<double>(nullable: false),
                    CurrentBalance = table.Column<double>(nullable: false),
                    TransactionId = table.Column<int>(nullable: true),
                    Matched = table.Column<bool>(nullable: false),
                    Shaded = table.Column<bool>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Commission = table.Column<double>(nullable: false),
                    CompanyCommission = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCashFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyCashFlow_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyCashFlow_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreasuryCashFlow",
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
                    Amount = table.Column<double>(nullable: false),
                    CurrentBalance = table.Column<double>(nullable: false),
                    TransactionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreasuryCashFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreasuryCashFlow_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCashFlow_TransactionId",
                table: "ClientCashFlow",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCashFlow_UserId",
                table: "ClientCashFlow",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCashFlow_TransactionId",
                table: "CompanyCashFlow",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCashFlow_UserId",
                table: "CompanyCashFlow",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_BeneficiaryId",
                table: "OutgoingTransfers",
                column: "BeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_CountryId",
                table: "OutgoingTransfers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_CurrencyId",
                table: "OutgoingTransfers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_ReceivingCompanyId",
                table: "OutgoingTransfers",
                column: "ReceivingCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_SenderId",
                table: "OutgoingTransfers",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_SendingClientId",
                table: "OutgoingTransfers",
                column: "SendingClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_SendingCompanyId",
                table: "OutgoingTransfers",
                column: "SendingCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryCashFlow_TransactionId",
                table: "TreasuryCashFlow",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCashFlow");

            migrationBuilder.DropTable(
                name: "CompanyCashFlow");

            migrationBuilder.DropTable(
                name: "OutgoingTransfers");

            migrationBuilder.DropTable(
                name: "TreasuryCashFlow");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
