using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstWebProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcentBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bank_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    program_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    procent = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcentBase", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcentBase");
        }
    }
}
