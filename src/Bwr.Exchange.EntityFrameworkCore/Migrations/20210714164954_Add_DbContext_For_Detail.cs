using Microsoft.EntityFrameworkCore.Migrations;

namespace Bwr.Exchange.Migrations
{
    public partial class Add_DbContext_For_Detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientBalance_Clients_ClientId",
                table: "ClientBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientBalance_Currencies_CurrencyId",
                table: "ClientBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientPhone_Clients_ClientId",
                table: "ClientPhone");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBalance_Companies_CompanyId",
                table: "CompanyBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBalance_Currencies_CurrencyId",
                table: "CompanyBalance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyBalance",
                table: "CompanyBalance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientPhone",
                table: "ClientPhone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientBalance",
                table: "ClientBalance");

            migrationBuilder.RenameTable(
                name: "CompanyBalance",
                newName: "CompanyBalances");

            migrationBuilder.RenameTable(
                name: "ClientPhone",
                newName: "ClientPhones");

            migrationBuilder.RenameTable(
                name: "ClientBalance",
                newName: "ClientBalances");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyBalance_CurrencyId",
                table: "CompanyBalances",
                newName: "IX_CompanyBalances_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyBalance_CompanyId",
                table: "CompanyBalances",
                newName: "IX_CompanyBalances_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientPhone_ClientId",
                table: "ClientPhones",
                newName: "IX_ClientPhones_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientBalance_CurrencyId",
                table: "ClientBalances",
                newName: "IX_ClientBalances_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientBalance_ClientId",
                table: "ClientBalances",
                newName: "IX_ClientBalances_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyBalances",
                table: "CompanyBalances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientPhones",
                table: "ClientPhones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientBalances",
                table: "ClientBalances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientBalances_Clients_ClientId",
                table: "ClientBalances",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientBalances_Currencies_CurrencyId",
                table: "ClientBalances",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPhones_Clients_ClientId",
                table: "ClientPhones",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBalances_Companies_CompanyId",
                table: "CompanyBalances",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBalances_Currencies_CurrencyId",
                table: "CompanyBalances",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientBalances_Clients_ClientId",
                table: "ClientBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientBalances_Currencies_CurrencyId",
                table: "ClientBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientPhones_Clients_ClientId",
                table: "ClientPhones");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBalances_Companies_CompanyId",
                table: "CompanyBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBalances_Currencies_CurrencyId",
                table: "CompanyBalances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyBalances",
                table: "CompanyBalances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientPhones",
                table: "ClientPhones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientBalances",
                table: "ClientBalances");

            migrationBuilder.RenameTable(
                name: "CompanyBalances",
                newName: "CompanyBalance");

            migrationBuilder.RenameTable(
                name: "ClientPhones",
                newName: "ClientPhone");

            migrationBuilder.RenameTable(
                name: "ClientBalances",
                newName: "ClientBalance");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyBalances_CurrencyId",
                table: "CompanyBalance",
                newName: "IX_CompanyBalance_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyBalances_CompanyId",
                table: "CompanyBalance",
                newName: "IX_CompanyBalance_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientPhones_ClientId",
                table: "ClientPhone",
                newName: "IX_ClientPhone_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientBalances_CurrencyId",
                table: "ClientBalance",
                newName: "IX_ClientBalance_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientBalances_ClientId",
                table: "ClientBalance",
                newName: "IX_ClientBalance_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyBalance",
                table: "CompanyBalance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientPhone",
                table: "ClientPhone",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientBalance",
                table: "ClientBalance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientBalance_Clients_ClientId",
                table: "ClientBalance",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientBalance_Currencies_CurrencyId",
                table: "ClientBalance",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPhone_Clients_ClientId",
                table: "ClientPhone",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBalance_Companies_CompanyId",
                table: "CompanyBalance",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBalance_Currencies_CurrencyId",
                table: "CompanyBalance",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
