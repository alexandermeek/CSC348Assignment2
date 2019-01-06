using Microsoft.EntityFrameworkCore.Migrations;

namespace CSC348Assignment2.Data.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "AspNetUsers",
                maxLength: 15,
                nullable: true);
        }
    }
}
