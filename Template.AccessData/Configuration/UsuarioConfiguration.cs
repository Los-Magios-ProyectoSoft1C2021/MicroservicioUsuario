using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        }
    }

}
