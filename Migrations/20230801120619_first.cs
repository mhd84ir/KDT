using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KDT.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarikhSabt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tarikhsodor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TarikhEtebar = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    NoeForosh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameSherkat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameVasete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameMahsol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tedad = table.Column<int>(type: "int", nullable: false),
                    FiGhablArzeshAfzode = table.Column<int>(type: "int", nullable: false),
                    MabdaHaml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Takhfif = table.Column<int>(type: "int", nullable: false),
                    ArzeshAfzode = table.Column<int>(type: "int", nullable: false),
                    GheymatNahaei = table.Column<int>(type: "int", nullable: false),
                    MablaghDaryafti = table.Column<int>(type: "int", nullable: false),
                    MojavezBargiri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeghdarBargiri = table.Column<int>(type: "int", nullable: false),
                    St = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
