using Microsoft.EntityFrameworkCore.Migrations;

namespace Bwr.Exchange.Migrations
{
    public partial class Update_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryActions_Clients_FromClientId",
                table: "TreasuryActions");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryActions_Companies_FromCompanyId",
                table: "TreasuryActions");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryActions_Clients_ToClientId",
                table: "TreasuryActions");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryActions_Companies_ToCompanyId",
                table: "TreasuryActions");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryActions_FromClientId",
                table: "TreasuryActions");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryActions_FromCompanyId",
                table: "TreasuryActions");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryActions_ToClientId",
                table: "TreasuryActions");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryActions_ToCompanyId",
                table: "TreasuryActions");

            migrationBuilder.DropColumn(
                name: "FromClientId",
                table: "TreasuryActions");

            migrationBuilder.DropColumn(
                name: "FromCompanyId",
                table: "TreasuryActions");

            migrationBuilder.DropColumn(
                name: "ToClientId",
                table: "TreasuryActions");

            migrationBuilder.DropColumn(
                name: "ToCompanyId",
                table: "TreasuryActions");

            migrationBuilder.AddColumn<int>(
                name: "ExchangePartyClientId",
                table: "TreasuryActions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExchangePartyCompanyId",
                table: "TreasuryActions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainAccountClientId",
                table: "TreasuryActions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainAccountCompanyId",
                table: "TreasuryActions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "CompanyCashFlows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InstrumentNo",
                table: "CompanyCashFlows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "ClientCashFlows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "ClientCashFlows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InstrumentNo",
                table: "ClientCashFlows",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_ExchangePartyClientId",
                table: "TreasuryActions",
                column: "ExchangePartyClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_ExchangePartyCompanyId",
                table: "TreasuryActions",
                column: "ExchangePartyCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_MainAccountClientId",
                table: "TreasuryActions",
                column: "MainAccountClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_MainAccountCompanyId",
                table: "TreasuryActions",
                column: "MainAccountCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCashFlows_CurrencyId",
                table: "CompanyCashFlows",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCashFlows_ClientId",
                table: "ClientCashFlows",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCashFlows_CurrencyId",
                table: "ClientCashFlows",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCashFlows_Clients_ClientId",
                table: "ClientCashFlows",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCashFlows_Currencies_CurrencyId",
                table: "ClientCashFlows",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCashFlows_Currencies_CurrencyId",
                table: "CompanyCashFlows",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryActions_Clients_ExchangePartyClientId",
                table: "TreasuryActions",
                column: "ExchangePartyClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryActions_Companies_ExchangePartyCompanyId",
                table: "TreasuryActions",
                column: "ExchangePartyCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryActions_Clients_MainAccountClientId",
                table: "TreasuryActions",
                column: "MainAccountClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryActions_Companies_MainAccountCompanyId",
                table: "TreasuryActions",
                column: "MainAccountCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCashFlows_Clients_ClientId",
                table: "ClientCashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCashFlows_Currencies_CurrencyId",
                table: "ClientCashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCashFlows_Currencies_CurrencyId",
                table: "CompanyCashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryActions_Clients_ExchangePartyClientId",
                table: "TreasuryActions");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryActions_Companies_ExchangePartyCompanyId",
                table: "TreasuryActions");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryActions_Clients_MainAccountClientId",
                table: "TreasuryActions");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryActions_Companies_MainAccountCompanyId",
                table: "TreasuryActions");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryActions_ExchangePartyClientId",
                table: "TreasuryActions");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryActions_ExchangePartyCompanyId",
                table: "TreasuryActions");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryActions_MainAccountClientId",
                table: "TreasuryActions");

            migrationBuilder.DropIndex(
                name: "IX_TreasuryActions_MainAccountCompanyId",
                table: "TreasuryActions");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCashFlows_CurrencyId",
                table: "CompanyCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_ClientCashFlows_ClientId",
                table: "ClientCashFlows");

            migrationBuilder.DropIndex(
                name: "IX_ClientCashFlows_CurrencyId",
                table: "ClientCashFlows");

            migrationBuilder.DropColumn(
                name: "ExchangePartyClientId",
                table: "TreasuryActions");

            migrationBuilder.DropColumn(
                name: "ExchangePartyCompanyId",
                table: "TreasuryActions");

            migrationBuilder.DropColumn(
                name: "MainAccountClientId",
                table: "TreasuryActions");

            migrationBuilder.DropColumn(
                name: "MainAccountCompanyId",
                table: "TreasuryActions");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "CompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "InstrumentNo",
                table: "CompanyCashFlows");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ClientCashFlows");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "ClientCashFlows");

            migrationBuilder.DropColumn(
                name: "InstrumentNo",
                table: "ClientCashFlows");

            migrationBuilder.AddColumn<int>(
                name: "FromClientId",
                table: "TreasuryActions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromCompanyId",
                table: "TreasuryActions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToClientId",
                table: "TreasuryActions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToCompanyId",
                table: "TreasuryActions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_FromClientId",
                table: "TreasuryActions",
                column: "FromClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_FromCompanyId",
                table: "TreasuryActions",
                column: "FromCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_ToClientId",
                table: "TreasuryActions",
                column: "ToClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryActions_ToCompanyId",
                table: "TreasuryActions",
                column: "ToCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryActions_Clients_FromClientId",
                table: "TreasuryActions",
                column: "FromClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryActions_Companies_FromCompanyId",
                table: "TreasuryActions",
                column: "FromCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryActions_Clients_ToClientId",
                table: "TreasuryActions",
                column: "ToClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryActions_Companies_ToCompanyId",
                table: "TreasuryActions",
                column: "ToCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
