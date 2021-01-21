using Microsoft.EntityFrameworkCore.Migrations;

namespace Global.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_AspNetUsers_userId",
                table: "Inscricoes");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Inscricoes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Inscricoes_userId",
                table: "Inscricoes",
                newName: "IX_Inscricoes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_AspNetUsers_UserId",
                table: "Inscricoes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_AspNetUsers_UserId",
                table: "Inscricoes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Inscricoes",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Inscricoes_UserId",
                table: "Inscricoes",
                newName: "IX_Inscricoes_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_AspNetUsers_userId",
                table: "Inscricoes",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
