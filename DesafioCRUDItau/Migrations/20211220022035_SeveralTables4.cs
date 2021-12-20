using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioCRUDItau.Migrations
{
    public partial class SeveralTables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gravidades_Usuarios_UsuarioId",
                table: "Gravidades");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoSolicitacaos_Usuarios_UsuarioId",
                table: "TipoSolicitacaos");

            migrationBuilder.DropIndex(
                name: "IX_TipoSolicitacaos_UsuarioId",
                table: "TipoSolicitacaos");

            migrationBuilder.DropIndex(
                name: "IX_Gravidades_UsuarioId",
                table: "Gravidades");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TipoSolicitacaos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Gravidades");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TipoSolicitacaos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TipoSolicitacaos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TipoSolicitacaos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Gravidades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoSolicitacaos_UsuarioId",
                table: "TipoSolicitacaos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Gravidades_UsuarioId",
                table: "Gravidades",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gravidades_Usuarios_UsuarioId",
                table: "Gravidades",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoSolicitacaos_Usuarios_UsuarioId",
                table: "TipoSolicitacaos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
