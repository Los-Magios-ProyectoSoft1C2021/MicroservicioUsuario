using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Template.Domain.Entities;

namespace Template.AccessData.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> rol)
        {
            rol.HasKey(p => p.RolId);
            rol.Property(p => p.RolId);

            rol.Property(p => p.Nombre)
               .IsRequired(true)
               .HasMaxLength(24);

            rol.Property(p => p.Descripcion)
               .IsRequired(true)
               .HasMaxLength(128);

            rol.HasData(
                new Rol { RolId = Guid.NewGuid(), Nombre = "Usuario", Descripcion = "Usuario el cual es capaz de reservar hoteles." },
                new Rol { RolId = Guid.NewGuid(), Nombre = "Admin", Descripcion = "El admin es aquel que puede ver los usuarios que hicieron reservas y modificar info de los hoteles" });
        }
    }

}
