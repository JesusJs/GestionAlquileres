using AppGestorPropiedades.Dominio.Entidades;
using AppGestorPropiedades.Dominio.Interfaces;
using AppGestorPropiedades.Dominio.Modelos;
using AppGestorPropiedades.Infraestructura.Datos.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorPropiedades.Infraestructura.Datos.Mappers
{
    public class AutoMapperFactory
    {
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add your mapping configurations here
                cfg.CreateMap<PropiedadesDTO, PropiedadesModelos>();
                cfg.CreateMap<PropiedadesModelos, Propiedades>();
                // ... and so on for other mappings
            });
            return config.CreateMapper();
        });

        public static IMapper GetMapper()
        {
            return _mapper.Value;
        }
    }
}
