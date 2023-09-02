using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KDT.Migrations
{
    public partial class firssec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PishId",
                table: "dolarDocs",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PishId",
                table: "dolarDocs");
        }
    }
}
