using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KDT.Migrations
{
    public partial class firs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dolarDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarikhSabt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tarikhsodor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TarikhEtebar = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    Komision = table.Column<int>(type: "int", nullable: false),
                    NameKharidar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameVasete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameMahsol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fi = table.Column<int>(type: "int", nullable: false),
                    MaghsadHaml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GheymatNahaei = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tonazh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hesab = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeghdarBargiri = table.Column<int>(type: "int", nullable: true),
                    SherkatId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HesabId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShomarePish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SharayetTahvil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dolarDocs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dolarDocs");
        }
    }
}
