using System;

namespace Template.Domain.DTOs.Response
{
    public class ResponseUsuarioDto
    {
        public Guid UsuarioId { get; set; }
        public string Rol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int Dni { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Nacionalidad { get; set; }
        public string Imagen { get; set; }

    }
}
