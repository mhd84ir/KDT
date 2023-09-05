using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KDT.Migrations
{
    public partial class _13sharivarr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lcRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarikhR = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tonazh = table.Column<int>(type: "int", nullable: false),
                    MablaghR = table.Column<int>(type: "int", nullable: false),
                    SherkatId = table.Column<int>(type: "int", nullable: false),
                    NameSherkat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vaste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tozih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lcRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lcRequests");
        }
    }
}
