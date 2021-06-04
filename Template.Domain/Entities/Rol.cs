using System;
using System.Collections.Generic;

namespace Template.Domain.Entities
{
    public class Rol
    {
        public Guid RolId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
