using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioCRUDItau.Migrations
{
    public partial class SeveralTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Decricao",
                table: "Gravidades");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Gravidades",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Gravidades");

            migrationBuilder.AddColumn<string>(
                name: "Decricao",
                table: "Gravidades",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
