using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaDesejosAPI.Migrations
{
    public partial class Relacionamento3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desejos_Usuarios_UsuarioId",
                table: "Desejos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Desejos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Desejos_Usuarios_UsuarioId",
                table: "Desejos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desejos_Usuarios_UsuarioId",
                table: "Desejos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Desejos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Desejos_Usuarios_UsuarioId",
                table: "Desejos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
