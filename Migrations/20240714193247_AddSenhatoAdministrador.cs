﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Eventos.Migrations
{
    /// <inheritdoc />
    public partial class AddSenhatoAdministrador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Administradores",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Administradores");
        }
    }
}
