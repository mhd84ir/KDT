using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KDT.Migrations
{
    public partial class firttttttttttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Tedad",
                table: "Documents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PishId",
                table: "Documents",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PishId",
                table: "Documents");

            migrationBuilder.AlterColumn<int>(
                name: "Tedad",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
