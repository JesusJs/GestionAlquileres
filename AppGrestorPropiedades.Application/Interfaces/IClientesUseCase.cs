using AppGestorPropiedades.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGrestorPropiedades.Application.Interfaces
{
    public  interface IClientesUseCase
    {
        ClientesModelos ObtenerSesion(ClientesModelos client);
    }
}
