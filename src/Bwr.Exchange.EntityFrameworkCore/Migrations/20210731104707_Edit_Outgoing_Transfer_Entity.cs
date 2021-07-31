using Microsoft.EntityFrameworkCore.Migrations;

namespace Bwr.Exchange.Migrations
{
    public partial class Edit_Outgoing_Transfer_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutgoingTransfers_Companies_ReceivingCompanyId",
                table: "OutgoingTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_OutgoingTransfers_Clients_SendingClientId",
                table: "OutgoingTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_OutgoingTransfers_Companies_SendingCompanyId",
                table: "OutgoingTransfers");

            migrationBuilder.DropIndex(
                name: "IX_OutgoingTransfers_ReceivingCompanyId",
                table: "OutgoingTransfers");

            migrationBuilder.DropIndex(
                name: "IX_OutgoingTransfers_SendingClientId",
                table: "OutgoingTransfers");

            migrationBuilder.DropIndex(
                name: "IX_OutgoingTransfers_SendingCompanyId",
                table: "OutgoingTransfers");

            migrationBuilder.DropColumn(
                name: "ReceivingCompanyId",
                table: "OutgoingTransfers");

            migrationBuilder.DropColumn(
                name: "SendingClientId",
                table: "OutgoingTransfers");

            migrationBuilder.DropColumn(
                name: "SendingCompanyId",
                table: "OutgoingTransfers");

            migrationBuilder.AddColumn<int>(
                name: "FromClientId",
                table: "OutgoingTransfers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromCompanyId",
                table: "OutgoingTransfers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToCompanyId",
                table: "OutgoingTransfers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_FromClientId",
                table: "OutgoingTransfers",
                column: "FromClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_FromCompanyId",
                table: "OutgoingTransfers",
                column: "FromCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_ToCompanyId",
                table: "OutgoingTransfers",
                column: "ToCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutgoingTransfers_Clients_FromClientId",
                table: "OutgoingTransfers",
                column: "FromClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutgoingTransfers_Companies_FromCompanyId",
                table: "OutgoingTransfers",
                column: "FromCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutgoingTransfers_Companies_ToCompanyId",
                table: "OutgoingTransfers",
                column: "ToCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutgoingTransfers_Clients_FromClientId",
                table: "OutgoingTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_OutgoingTransfers_Companies_FromCompanyId",
                table: "OutgoingTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_OutgoingTransfers_Companies_ToCompanyId",
                table: "OutgoingTransfers");

            migrationBuilder.DropIndex(
                name: "IX_OutgoingTransfers_FromClientId",
                table: "OutgoingTransfers");

            migrationBuilder.DropIndex(
                name: "IX_OutgoingTransfers_FromCompanyId",
                table: "OutgoingTransfers");

            migrationBuilder.DropIndex(
                name: "IX_OutgoingTransfers_ToCompanyId",
                table: "OutgoingTransfers");

            migrationBuilder.DropColumn(
                name: "FromClientId",
                table: "OutgoingTransfers");

            migrationBuilder.DropColumn(
                name: "FromCompanyId",
                table: "OutgoingTransfers");

            migrationBuilder.DropColumn(
                name: "ToCompanyId",
                table: "OutgoingTransfers");

            migrationBuilder.AddColumn<int>(
                name: "ReceivingCompanyId",
                table: "OutgoingTransfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SendingClientId",
                table: "OutgoingTransfers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SendingCompanyId",
                table: "OutgoingTransfers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_ReceivingCompanyId",
                table: "OutgoingTransfers",
                column: "ReceivingCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_SendingClientId",
                table: "OutgoingTransfers",
                column: "SendingClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingTransfers_SendingCompanyId",
                table: "OutgoingTransfers",
                column: "SendingCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutgoingTransfers_Companies_ReceivingCompanyId",
                table: "OutgoingTransfers",
                column: "ReceivingCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutgoingTransfers_Clients_SendingClientId",
                table: "OutgoingTransfers",
                column: "SendingClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutgoingTransfers_Companies_SendingCompanyId",
                table: "OutgoingTransfers",
                column: "SendingCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
