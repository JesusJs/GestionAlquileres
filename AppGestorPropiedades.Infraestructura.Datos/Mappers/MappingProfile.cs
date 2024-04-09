using AppGestorPropiedades.Dominio.Entidades;
using AppGestorPropiedades.Dominio.Interfaces;
using AppGestorPropiedades.Dominio.Modelos;
using AppGestorPropiedades.Infraestructura.Datos;
using AppGestorPropiedades.Infraestructura.Datos.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorPropiedades.Infraestructura.Datos.Mappers
{
    public class MappingProfile : Profile
    {
        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public MappingProfile()
        {
            CreateMap<PropiedadesDTO, PropiedadesModelos>();
            CreateMap<PropiedadesModelos, Propiedades>();
            CreateMap<Propiedades, PropiedadesModelos>();
            CreateMap<PropiedadesModelos, PropiedadesDTO>();

            CreateMap<ClientesDTO, ClientesModelos>();
            CreateMap<ClientesModelos, Clientes>();
            CreateMap<Clientes, ClientesModelos>();
            CreateMap<ClientesModelos, ClientesDTO>();
        }
    }
}
