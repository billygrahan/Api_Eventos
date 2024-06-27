using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Eventos.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailtoAdministrador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    AdmnistradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.AdmnistradorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_AdministradorId",
                table: "Eventos",
                column: "AdministradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Administradores_AdministradorId",
                table: "Eventos",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "AdmnistradorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Administradores_AdministradorId",
                table: "Eventos");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_AdministradorId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Eventos");
        }
    }
}
