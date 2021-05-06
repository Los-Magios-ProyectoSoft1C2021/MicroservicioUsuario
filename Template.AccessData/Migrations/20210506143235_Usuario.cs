using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.AccessData.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rol = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                    table.ForeignKey(
                        name: "FK_Roles_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UsuarioId",
                table: "Roles",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
