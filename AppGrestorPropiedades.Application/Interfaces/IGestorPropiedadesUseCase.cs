using AppGestorPropiedades.Dominio.Entidades;
using AppGestorPropiedades.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGrestorPropiedades.Application.Interfaces
{
    public interface IGestorPropiedadesUseCase
    {
        List<PropiedadesModelos> Listar(int precioMin, int precioMax);


        PropiedadesModelos Agregar(PropiedadesModelos entidad);

        void Editar(PropiedadesModelos entidad);

        void Arrendar(PropiedadesModelos entidad);
        PropiedadesModelos Eliminar(int id); 

    }
}
