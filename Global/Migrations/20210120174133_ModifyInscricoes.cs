using Microsoft.EntityFrameworkCore.Migrations;

namespace Global.Migrations
{
    public partial class ModifyInscricoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Inscricoes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Inscricoes");
        }
    }
}
