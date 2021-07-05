﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Template.AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "RolId", "Descripcion", "Nombre" },
                values: new object[] { 1, "Usuario el cual es capaz de reservar hoteles.", "Usuario" });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "RolId", "Descripcion", "Nombre" },
                values: new object[] { 2, "El admin es aquel que puede ver los usuarios que hicieron reservas y modificar info de los hoteles", "Admin" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "Apellido", "Contraseña", "Correo", "Dni", "Imagen", "Nacionalidad", "Nombre", "NombreUsuario", "RolId", "Telefono" },
                values: new object[] { new Guid("8e58b2e3-fca5-4b65-9c99-32a418fb7336"), "Test", "Test12345", "test@bookingunaj.com", 1111111, "/img/user.png", "Argentina", "Usuario", "test", 1, "4444-5555" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "Apellido", "Contraseña", "Correo", "Dni", "Imagen", "Nacionalidad", "Nombre", "NombreUsuario", "RolId", "Telefono" },
                values: new object[] { new Guid("517a046d-a1f0-4760-81ff-e4c6685fcedf"), "Principal", "Admin12345", "admin@bookingunaj.com", 31252875, "/img/user.png", "Argentina", "Admin", "admin", 2, "4444-5555" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
