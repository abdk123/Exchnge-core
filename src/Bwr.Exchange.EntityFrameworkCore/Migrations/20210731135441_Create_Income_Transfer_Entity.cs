using Microsoft.EntityFrameworkCore.Migrations;

namespace Bwr.Exchange.Migrations
{
    public partial class Create_Income_Transfer_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceivedAmount",
                table: "OutgoingTransfers");

            migrationBuilder.AddColumn<double>(
                name: "CompanyCommission",
                table: "OutgoingTransfers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ReceivesdAmount",
                table: "OutgoingTransfers",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyCommission",
                table: "OutgoingTransfers");

            migrationBuilder.DropColumn(
                name: "ReceivesdAmount",
                table: "OutgoingTransfers");

            migrationBuilder.AddColumn<double>(
                name: "ReceivedAmount",
                table: "OutgoingTransfers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
