using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KDT.Migrations
{
    public partial class firssecccccc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FirstOfName",
                table: "mahsolSas",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FirstOfName",
                table: "mahsolSas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }
    }
}
