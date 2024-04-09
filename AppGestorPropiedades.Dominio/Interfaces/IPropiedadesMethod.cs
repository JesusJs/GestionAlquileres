using AppGestorPropiedades.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorPropiedades.Dominio.Interfaces
{
    public interface IPropiedadesMethod
    {
        Propiedades ObtenerPropiedadesId(int Id);
        Propiedades actualizar(Propiedades entidad);
    }
}
