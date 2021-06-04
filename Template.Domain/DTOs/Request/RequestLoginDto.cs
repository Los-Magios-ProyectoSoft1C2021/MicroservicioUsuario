using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.DTOs.Request
{
    public class RequestLoginDto
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
    }
}
