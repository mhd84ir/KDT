using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KDT.Migrations
{
    public partial class _24mordad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MablaghDaryafti",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "St",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "MojavezBargiri",
                table: "Documents",
                newName: "Tonazh");

            migrationBuilder.AddColumn<string>(
                name: "Hesab",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SherkatId",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShomarePish",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hesab",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "SherkatId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ShomarePish",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "Tonazh",
                table: "Documents",
                newName: "MojavezBargiri");

            migrationBuilder.AddColumn<int>(
                name: "MablaghDaryafti",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "St",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
