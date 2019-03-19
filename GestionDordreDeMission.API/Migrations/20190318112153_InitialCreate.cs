using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionDordreDeMission.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", false),
                    NumPasseport = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    Nom = table.Column<string>(nullable:false),
                    PostEmp = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
