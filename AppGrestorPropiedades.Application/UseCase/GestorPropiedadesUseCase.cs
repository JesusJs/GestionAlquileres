using AppGestorPropiedades.Dominio.Entidades;
using AppGestorPropiedades.Dominio.Interfaces;
using AppGestorPropiedades.Dominio.Interfaces.Repositorios;
using AppGestorPropiedades.Dominio.Modelos;
using AppGrestorPropiedades.Application.Interfaces;
using AutoMapper;

namespace AppGrestorPropiedades.Application.UseCase
{
    public class GestorPropiedadesUseCase : IGestorPropiedadesUseCase
    {
        #region Importaciones
        public readonly IRepositorioBase<Propiedades> repoPropiedades;
        private readonly IMapper mapper;
        public GestorPropiedadesUseCase(IRepositorioBase<Propiedades> _repoPropiedades, IMapper _mapper) 
        { 
            repoPropiedades = _repoPropiedades;
            mapper = _mapper;
        }
        #endregion
        public List<PropiedadesModelos> Listar(int precioMin, int PrecioMax)
        {
            var result = new List<PropiedadesModelos>();
            try
            {
                 var listarPropiedades = repoPropiedades.Listar(precioMin, PrecioMax).ToList();
                 result = mapper.Map<List<PropiedadesModelos>>(listarPropiedades);
            }
            catch( Exception ex)
            {

            }
            return result;
        }

        public PropiedadesModelos Agregar(PropiedadesModelos datos)
        {
            var result = new PropiedadesModelos();
            try
            {

                var mensajeError = ValidarDatosAgregar(datos);
                if (!string.IsNullOrEmpty(mensajeError))
                {
                    result.Mensaje = mensajeError;
                    return result;
                }
                var entidad = mapper.Map<Propiedades>(datos);

                var resultRep = repoPropiedades.Agregar(entidad);
                result = mapper.Map<PropiedadesModelos>(resultRep);
            }
            catch (Exception e) { 

            }
            return result; ;   
        }

        public PropiedadesModelos Eliminar(int id)
        {
            PropiedadesModelos result = new PropiedadesModelos();
            try
            {
                var propiedad = repoPropiedades.ObtenerPropiedadesId(id);
                if (propiedad == null)
                {
                    throw new KeyNotFoundException($"Propiedad con ID '{id}' no encontrada");
                }

                var fechaCreacion = propiedad.fechaArrendamiento;
                var diferenciaDias = (DateTime.Now - fechaCreacion).TotalDays;
                if (diferenciaDias >= 30)
                {
                    throw new InvalidOperationException("Solo se pueden eliminar propiedades con menos de un mes de antigüedad");
                }

                repoPropiedades.Eliminar(id);
            }
            catch
            {
            }
            return result;
        }

        public void Arrendar(PropiedadesModelos entidad)
        {
            var propiedad = repoPropiedades.ObtenerPropiedadesId(entidad.propiedadesId);
            if (propiedad == null)
            {
                throw new KeyNotFoundException($"Propiedad con ID '{entidad.propiedadesId}' no encontrada");
            }
            if (!propiedad.disponibilidad)
            {
                throw new InvalidOperationException("La propiedad no está disponible para arrendar");
            }
            propiedad.disponibilidad = false;
            propiedad.fechaArrendamiento = DateTime.Now;

            repoPropiedades.Editar(propiedad);
        }

        public void Editar(PropiedadesModelos entidad)
        {
            PropiedadesModelos result = new PropiedadesModelos();
            var propiedad = repoPropiedades.ObtenerPropiedadesId(entidad.propiedadesId);
            ValidarEditar(entidad, propiedad);
            propiedad.nombre = entidad.nombre;
            propiedad.disponibilidad = entidad.disponibilidad;
            propiedad.urlImagen = entidad.urlImagen;
            propiedad.ubicacion = entidad.ubicacion;
            propiedad.precio = entidad.precio;

            repoPropiedades.Editar(propiedad);
        }

        #region Validaciones
        private string ValidarDatosAgregar(PropiedadesModelos datos)
        {
            var result = new PropiedadesModelos();
            var listarPropiedades = repoPropiedades.Listar();
            if (datos == null)
                return "Las 'Propiedades' es requerido";
                

           var nombreValido = !listarPropiedades.Any(e => e.nombre == datos.nombre);
            if (!nombreValido)
                return "El nombre de la propiedad ya está registrado";
              
            var ubicacionesValidas = new HashSet<string> { "Medellin", "Bogota", "Cali", "Cartagena" };
            if (!ubicacionesValidas.Contains(datos.ubicacion))
                return "La ubicación no es válida";

            if (datos.precio <= 0)
                return "El precio debe ser mayor a 0";

            if (datos.ubicacion == "Bogota" || datos.ubicacion == "Cali")
            {
                if (datos.precio < 2000000)
                    return "El precio para Bogotá y Cali debe ser mayor a 2.000.000";
            }
            if (datos.nombre == "" )
            {
                return "El nombre no debe ser vacio";
            }
            return string.Empty;
        }
        private void ValidarEditar(PropiedadesModelos entidad, Propiedades propiedad) {
            if (propiedad == null)
            {
                throw new KeyNotFoundException($"Propiedad con ID '{entidad.propiedadesId}' no encontrada");
            }

            if (string.IsNullOrEmpty(entidad.nombre) || string.IsNullOrEmpty(entidad.ubicacion) || entidad.precio <= 0)
            {
                throw new InvalidOperationException("Los campos 'Nombre', 'Ubicación' y 'Precio' son obligatorios");
            }

            var ubicacionesValidas = new HashSet<string> { "Medellin", "Bogota", "Cali", "Cartagena" };
            if (ubicacionesValidas.Contains(entidad.ubicacion) && entidad.precio < 2000000)
            {
                throw new InvalidOperationException("El precio para Bogotá y Cali debe ser mayor a 2.000.000");
            }
            if (!propiedad.disponibilidad)
            {
                if (entidad.ubicacion != propiedad.ubicacion)
                {
                    throw new InvalidOperationException("No se puede modificar la ubicación de una propiedad arrendada");
                }
                if (entidad.precio != propiedad.precio)
                {
                    throw new InvalidOperationException("No se puede modificar el precio de una propiedad arrendada");
                }
            }

        }

        #endregion
    }
}
