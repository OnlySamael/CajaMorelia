using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteDbModel>
    {
        public void Configure(EntityTypeBuilder<ClienteDbModel> builder)
        {
            builder.ToTable("clientes");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.CorreoElectronico)
                .IsRequired();

            builder.Property(c => c.Telefono)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
