using AppGestorPropiedades.Dominio.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorPropiedades.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidad>
        : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<int>, IListar<TEntidad>, IPropiedadesMethod
    {
        List<Propiedades> Listar();
    }
}
