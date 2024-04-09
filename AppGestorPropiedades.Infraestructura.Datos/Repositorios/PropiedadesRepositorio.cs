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
    public class PropiedadesRepositorio : IRepositorioBase<Propiedades>
    {

        private PropiedadesContexto db;

        public PropiedadesRepositorio(PropiedadesContexto _db)
        {
            db = _db;
        }

        public Propiedades Agregar(Propiedades entidad)
        {
            db.Propiedades.Add(entidad);

            db.SaveChanges();
            entidad = db.Propiedades.Find(entidad.propiedadesId);

            return entidad;
        }

        public void Editar(Propiedades entidad)
        {
            var propiedadDb = db.Propiedades.Find(entidad.propiedadesId);

            if (propiedadDb == null)
            {
                throw new KeyNotFoundException($"Propiedad con ID '{entidad.propiedadesId}' no encontrada");
            }

            propiedadDb.nombre = entidad.nombre;  
            propiedadDb.ubicacion = entidad.ubicacion; 
            propiedadDb.urlImagen = entidad.urlImagen;  
                                                        
            propiedadDb.precio = entidad.precio;  

            db.Entry(propiedadDb).State = EntityState.Modified;

            db.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var entidad = db.Propiedades.Find(id);
            db.Propiedades.Remove(entidad);

            db.SaveChanges();
        }

        public List<Propiedades> Listar(int precioMin, int precioMax)
        {
            return db.Propiedades.Where(e => e.disponibilidad == true && e.precio >= precioMin || e.precio <= precioMax).ToList();
        }
        public List<Propiedades> Listar()
        {
            return db.Propiedades.ToList();
        }

        public Propiedades ObtenerPropiedadesId(int Id)
        {
            return db.Propiedades.Where(e=> e.propiedadesId == Id ).First();
        }

        public Propiedades actualizar(Propiedades entidad) 
        {
            db.Attach(entidad);

            db.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return entidad;
        }
    }
}
