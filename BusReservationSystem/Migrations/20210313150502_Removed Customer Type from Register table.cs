using Microsoft.EntityFrameworkCore.Migrations;

namespace BusReservationSystem.Migrations
{
    public partial class RemovedCustomerTypefromRegistertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerType",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
