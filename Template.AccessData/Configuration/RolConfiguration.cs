using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Entities;

namespace Template.AccessData.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> rol)
        {
            rol.HasKey(p => p.RolId);
            rol.Property(p => p.RolId)
               .ValueGeneratedOnAdd();

            rol.Property(p => p.Nombre)
               .IsRequired(true)
               .HasMaxLength(24);

            rol.Property(p => p.Descripcion)
               .IsRequired(true)
               .HasMaxLength(128);
        }
    }
}
