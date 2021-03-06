using Microsoft.EntityFrameworkCore;
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
            var usuarios = await _context.Usuario
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
                })
                .ToListAsync();

            return usuarios;
        }

        public async Task<ResponseUsuarioDto> GetById(int usuarioId)
        {
            var usuario = await _context.Usuario
                .Where(u => u.UsuarioId == usuarioId)
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
                })
                .FirstOrDefaultAsync();

            return usuario;
        } 

        public async Task<ResponseLoginDto> GetUsuarioLogin(string nombreUsuario, string contraseña)
        {
            var login = await _context.Usuario
                .Where(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña)
                .Select(u => new ResponseLoginDto
                {
                    UsuarioId = u.UsuarioId,
                    NombreUsuario = u.NombreUsuario,
                    Rol = u.RolNavegator.Nombre,
                    Correo = u.Correo
                })
                .FirstOrDefaultAsync();

            return login;
        }

        public async Task<bool> CheckIfExistsByNombreUsuario(string nombreUsuario)
        {
            var exists = await _context.Usuario
                .AnyAsync(u => u.NombreUsuario == nombreUsuario);

            return exists;
        }
    }
}
