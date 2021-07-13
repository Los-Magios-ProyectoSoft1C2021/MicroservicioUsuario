using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Template.Domain.Entities;

namespace Template.AccessData.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.UsuarioId);
            builder.Property(p => p.UsuarioId)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Nombre)
                   .IsRequired(true)
                   .HasMaxLength(64);

            builder.Property(p => p.Apellido)
                   .IsRequired(true)
                   .HasMaxLength(64);

            builder.Property(p => p.Dni)
                   .IsRequired(true);

            builder.Property(p => p.NombreUsuario)
                   .IsRequired(true)
                   .HasMaxLength(64);

            builder.HasIndex(p => p.NombreUsuario)
                .IsUnique();

            builder.Property(p => p.Contraseña)
                   .IsRequired(true)
                   .HasMaxLength(64);

            builder.Property(p => p.Correo)
                   .IsRequired(true)
                   .HasMaxLength(128);

            builder.Property(p => p.Telefono)
                   .IsRequired(true)
                   .HasMaxLength(16);

            builder.Property(p => p.Imagen)
                   .IsRequired(true)
                   .HasMaxLength(128);

            builder.Property(p => p.Nacionalidad)
                   .IsRequired(true)
                   .HasMaxLength(128);

            builder.HasOne<Rol>(p => p.RolNavegator).WithMany(p => p.Usuario).HasForeignKey(k => k.RolId);

            builder.HasData(
                new Usuario
                {
                    UsuarioId = 1,
                    RolId = 2,
                    Nombre = "Admin",
                    Apellido = "Principal",
                    NombreUsuario = "admin",
                    Contraseña = "12345678",
                    Dni = 31252875,
                    Correo = "admin@bookingunaj.com",
                    Telefono = "4444-5555",
                    Nacionalidad = "Argentina",
                    Imagen = "/img/user.png",
                },
                new Usuario
                {
                    UsuarioId = 2,
                    RolId = 1,
                    Nombre = "Usuario",
                    Apellido = "Test",
                    NombreUsuario = "test",
                    Contraseña = "12345678",
                    Dni = 1111111,
                    Correo = "test@bookingunaj.com",
                    Telefono = "4444-5555",
                    Nacionalidad = "Argentina",
                    Imagen = "/img/user.png"
                });
        }
    }

}
