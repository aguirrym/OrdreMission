using Microsoft.EntityFrameworkCore.Migrations;

namespace OrdreMission.API.Migrations
{
    public partial class AddedEmployEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeRed",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NumPassport = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    NOM = table.Column<string>(nullable: true),
                    FonctionEmp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRed", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeRed");
        }
    }
}
