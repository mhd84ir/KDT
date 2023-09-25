using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KDT.Migrations
{
    public partial class _27shahrivar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lcfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarikhSabt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tarikhsodor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarikhEtebar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    MaghsadHaml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameSherkat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameVasete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameMahsol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankGoshayesh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiGhablArzeshAfzode = table.Column<int>(type: "int", nullable: false),
                    MabdaHaml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Takhfif = table.Column<int>(type: "int", nullable: false),
                    ArzeshAfzode = table.Column<int>(type: "int", nullable: false),
                    GheymatNahaei = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tonazh = table.Column<int>(type: "int", nullable: false),
                    MeghdarBargiri = table.Column<int>(type: "int", nullable: true),
                    SherkatId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankKargozari = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KomisionVasete = table.Column<int>(type: "int", nullable: true),
                    LCDay = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tozih = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sepam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarikhGoshayesh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShomarePish = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lcfs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lcfs");
        }
    }
}
