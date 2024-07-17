using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Eventos.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailandSenhaToParticipante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "Paticipantes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Paticipantes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMail",
                table: "Paticipantes");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Paticipantes");
        }
    }
}
