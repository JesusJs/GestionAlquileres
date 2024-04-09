using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGestorPropiedades.Dominio;
using AppGestorPropiedades.Dominio.Entidades;
using AppGestorPropiedades.Dominio.Interfaces.Repositorios;
using AppGestorPropiedades.Infraestructura.Datos.Contexto;
using Microsoft.EntityFrameworkCore;

namespace AppGestorPropiedades.Infraestructura.Datos.Repositorios
{
    public class ClientesRepositorio : IClientesRepositorio
    {

        private PropiedadesContexto db;

        public ClientesRepositorio(PropiedadesContexto _db)
        {
            db = _db;
        }

        public Clientes ObtenerSesion(Clientes client)
        {
            var cliente = db.Clientes.Where(c => c.usuario == client.usuario).FirstOrDefault();

            return cliente;
        }

}
}
