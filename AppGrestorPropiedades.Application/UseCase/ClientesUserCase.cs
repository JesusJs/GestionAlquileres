using AppGestorPropiedades.Dominio.Entidades;
using AppGestorPropiedades.Dominio.Interfaces.Repositorios;
using AppGestorPropiedades.Dominio.Modelos;
using AppGrestorPropiedades.Dominio.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGrestorPropiedades.Application.UseCase
{


        public class ClientesUserCase : IClientesUseCase
        {
            public readonly IClientesRepositorio clientes;
            private readonly IMapper mapper;
            public ClientesUserCase(IClientesRepositorio _clientes, IMapper _mapper)
            {
                clientes = _clientes;
                mapper = _mapper;
            }

            public ClientesModelos ObtenerSesion(ClientesModelos client)
            {

                var clientesEntidad = mapper.Map<Clientes>(client);
                var usuario = clientes.ObtenerSesion(clientesEntidad);

                return  mapper.Map<ClientesModelos>(usuario);
            }

        }

}
