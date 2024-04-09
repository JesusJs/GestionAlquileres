using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppGestorPropiedades.Dominio;
using AppGestorPropiedades.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGestorPropiedades.Infraestructura.Datos.Configs
{
    public class PropiedadesConfig : IEntityTypeConfiguration<Propiedades>
    {
        public void Configure(EntityTypeBuilder<Propiedades> builder)
        {
            builder.ToTable("Propiedades");
        }
    }
}
