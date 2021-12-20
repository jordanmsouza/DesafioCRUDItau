using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioCRUDItau.Migrations
{
    public partial class SeveralTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gravidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Decricao = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gravidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gravidades_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoSolicitacaos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSolicitacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoSolicitacaos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chamados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GravidadeId = table.Column<int>(nullable: false),
                    TipoSolicitacaoId = table.Column<int>(nullable: false),
                    Assunto = table.Column<string>(nullable: true),
                    Menssagem = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chamados_Gravidades_GravidadeId",
                        column: x => x.GravidadeId,
                        principalTable: "Gravidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamados_TipoSolicitacaos_TipoSolicitacaoId",
                        column: x => x.TipoSolicitacaoId,
                        principalTable: "TipoSolicitacaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamados_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_GravidadeId",
                table: "Chamados",
                column: "GravidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_TipoSolicitacaoId",
                table: "Chamados",
                column: "TipoSolicitacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_UsuarioId",
                table: "Chamados",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Gravidades_UsuarioId",
                table: "Gravidades",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoSolicitacaos_UsuarioId",
                table: "TipoSolicitacaos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamados");

            migrationBuilder.DropTable(
                name: "Gravidades");

            migrationBuilder.DropTable(
                name: "TipoSolicitacaos");
        }
    }
}
