using Microsoft.EntityFrameworkCore.Migrations;

namespace BusReservationSystem.Migrations
{
    public partial class NameofcolumnContactNumberchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "AspNetUsers");
        }
    }
}
