using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Template.Domain.Entities;

namespace Template.AccessData.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> usuario)
        {
            usuario.HasKey(p => p.UsuarioId);
            usuario.Property(p => p.UsuarioId)
                   .ValueGeneratedOnAdd();

            usuario.Property(p => p.Nombre)
                   .IsRequired(true)
                   .HasMaxLength(64);

            usuario.Property(p => p.Apellido)
                   .IsRequired(true)
                   .HasMaxLength(64);

            usuario.Property(p => p.Dni)
                   .IsRequired(true);

            usuario.Property(p => p.NombreUsuario)
                   .IsRequired(true)
                   .HasMaxLength(64);

            usuario.Property(p => p.Contraseña)
                   .IsRequired(true)
                   .HasMaxLength(64);

            usuario.Property(p => p.Correo)
                   .IsRequired(true)
                   .HasMaxLength(128);

            usuario.Property(p => p.Telefono)
                   .IsRequired(true)
                   .HasMaxLength(16);

            usuario.Property(p => p.Imagen)
                   .IsRequired(true)
                   .HasMaxLength(128);

            usuario.Property(p => p.Nacionalidad)
                   .IsRequired(true)
                   .HasMaxLength(128);

            usuario.HasOne<Rol>(p => p.RolNavegator).WithMany(p => p.Usuario).HasForeignKey(k => k.RolId);

            usuario.HasData(
                new Usuario 
                { 
                    UsuarioId = Guid.NewGuid(),
                    RolId = 2,
                    Nombre = "Admin",
                    Apellido = "Principal",
                    NombreUsuario = "admin",
                    Contraseña = "Admin12345",
                    Dni = 31252875,
                    Correo = "admin@bookingunaj.com",
                    Telefono = "4444-5555",
                    Nacionalidad = "Argentina",
                    Imagen = "/img/user.png",
                },
                new Usuario
                {
                    UsuarioId = Guid.NewGuid(),
                    RolId = 1,
                    Nombre = "Usuario",
                    Apellido = "Test",
                    NombreUsuario = "test",
                    Contraseña = "Test12345",
                    Dni = 1111111,
                    Correo = "test@bookingunaj.com",
                    Telefono = "4444-5555",
                    Nacionalidad = "Argentina",
                    Imagen = "/img/user.png"
                });
        }
    }

}
