using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KDT.Migrations
{
    public partial class firssecccc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstOfName",
                table: "mahsolSas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HSCode",
                table: "mahsolSas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstOfName",
                table: "mahsolSas");

            migrationBuilder.DropColumn(
                name: "HSCode",
                table: "mahsolSas");
        }
    }
}
