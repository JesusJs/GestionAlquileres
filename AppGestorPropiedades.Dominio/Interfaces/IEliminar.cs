using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorPropiedades.Dominio.Interfaces
{
    public interface IEliminar<TEntidadID>
    {
        void Eliminar(int id);
    }
}
