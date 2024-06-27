using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Eventos.Migrations
{
    /// <inheritdoc />
    public partial class concertAdministradorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdmnistradorId",
                table: "Administradores",
                newName: "AdministradorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdministradorId",
                table: "Administradores",
                newName: "AdmnistradorId");
        }
    }
}
