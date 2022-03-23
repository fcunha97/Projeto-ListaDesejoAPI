using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaDesejosAPI.Migrations
{
    public partial class Relacionamento2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desejos_Usuarios_UsuarioID",
                table: "Desejos");

            migrationBuilder.DropIndex(
                name: "IX_Desejos_UsuarioID",
                table: "Desejos");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Desejos",
                newName: "UsuarioId");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Desejos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Desejos_UsuarioId",
                table: "Desejos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desejos_Usuarios_UsuarioId",
                table: "Desejos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desejos_Usuarios_UsuarioId",
                table: "Desejos");

            migrationBuilder.DropIndex(
                name: "IX_Desejos_UsuarioId",
                table: "Desejos");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Desejos",
                newName: "UsuarioID");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "Desejos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Desejos_UsuarioID",
                table: "Desejos",
                column: "UsuarioID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Desejos_Usuarios_UsuarioID",
                table: "Desejos",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
