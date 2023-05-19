using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addRequestStatusToRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Requests");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Requests",
                type: "bit",
                nullable: true);
        }
    }
}
