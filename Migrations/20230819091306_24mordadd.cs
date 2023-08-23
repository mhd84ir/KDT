using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KDT.Migrations
{
    public partial class _24mordadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "sherkats");
        }
    }
}
