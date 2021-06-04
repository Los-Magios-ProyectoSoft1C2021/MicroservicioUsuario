﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Domain.DTOs.Response;
using Template.Domain.Queries;


namespace Template.AccessData.Queries
{
    public class UsuarioQuery : IUsuarioQuery
    {
        private readonly UsuarioDbContext _context;

        public UsuarioQuery(UsuarioDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseUsuarioDto>> GetAll()
        {
            var usuarios = await _context.Usuarios
                .Select(u => new ResponseUsuarioDto
                {
                    UsuarioId = u.UsuarioId,
                    Rol = u.RolNavegator.Descripcion,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    NombreUsuario = u.NombreUsuario,
                    Contraseña = u.Contraseña,
                    Dni = u.Dni,
                    Correo = u.Correo,
                    Telefono = u.Telefono,
                    Nacionalidad = u.Nacionalidad,
                    Imagen = u.Imagen,
                }).ToListAsync();
            return usuarios;
        }
    }
}
