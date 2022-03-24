using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaDesejosAPI.Migrations
{
    public partial class Nomeatualizadodelogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Loguin",
                table: "Usuarios",
                newName: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Usuarios",
                newName: "Loguin");
        }
    }
}
