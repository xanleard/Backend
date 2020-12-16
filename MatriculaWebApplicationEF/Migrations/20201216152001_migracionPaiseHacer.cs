using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWebApplicationEF.Migrations
{
    public partial class migracionPaiseHacer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaisHacerId",
                schema: "dbo",
                table: "Estudiantes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaisHacer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaisHacer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_PaisHacerId",
                schema: "dbo",
                table: "Estudiantes",
                column: "PaisHacerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_PaisHacer_PaisHacerId",
                schema: "dbo",
                table: "Estudiantes",
                column: "PaisHacerId",
                principalTable: "PaisHacer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_PaisHacer_PaisHacerId",
                schema: "dbo",
                table: "Estudiantes");

            migrationBuilder.DropTable(
                name: "PaisHacer");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_PaisHacerId",
                schema: "dbo",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "PaisHacerId",
                schema: "dbo",
                table: "Estudiantes");
        }
    }
}
