using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KDT.Migrations
{
    public partial class _12shahrivarrrr : Migration
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
                    Tedad = table.Column<int>(type: "int", nullable: true),
                    FiGhablArzeshAfzode = table.Column<int>(type: "int", nullable: false),
                    MabdaHaml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Takhfif = table.Column<int>(type: "int", nullable: false),
                    ArzeshAfzode = table.Column<int>(type: "int", nullable: false),
                    GheymatNahaei = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tonazh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hesab = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeghdarBargiri = table.Column<int>(type: "int", nullable: false),
                    SherkatId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HesabId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PishId = table.Column<int>(type: "int", nullable: true),
                    ShomarePish = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

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
                    Tonazh = table.Column<int>(type: "int", nullable: false),
                    Hesab = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeghdarBargiri = table.Column<int>(type: "int", nullable: true),
                    SherkatId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShomarePish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PishId = table.Column<int>(type: "int", nullable: true),
                    SharayetTahvil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiMablaghGhabelEzhar = table.Column<int>(type: "int", nullable: false),
                    MablaghGhabelEzhar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dolarDocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hesabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameShobe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShomareShaba = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hesabs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kharidarDolars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kharidarDolars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lCKhs",
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
                    table.PrimaryKey("PK_lCKhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mahsols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMahsol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mahsols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mahsolSas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMahsol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstOfName = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mahsolSas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sherkats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSherkat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShomareSabt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShenaseMeli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codeposti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Neshani = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sherkats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "dolarDocs");

            migrationBuilder.DropTable(
                name: "hesabs");

            migrationBuilder.DropTable(
                name: "kharidarDolars");

            migrationBuilder.DropTable(
                name: "lCKhs");

            migrationBuilder.DropTable(
                name: "mahsols");

            migrationBuilder.DropTable(
                name: "mahsolSas");

            migrationBuilder.DropTable(
                name: "sherkats");
        }
    }
}
