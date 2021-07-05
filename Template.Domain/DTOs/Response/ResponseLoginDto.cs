using System;

namespace Template.Domain.DTOs.Response
{
    public class ResponseLoginDto
    {
        public Guid UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
        public string Correo { get; set; }
    }
}
