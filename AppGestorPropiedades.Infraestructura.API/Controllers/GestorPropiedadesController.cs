using AppGestorPropiedades.Dominio.Interfaces;
using AppGestorPropiedades.Infraestructura.Datos.DTO;
using Microsoft.AspNetCore.Mvc;
using AppGrestorPropiedades.Application.Interfaces;
using AppGestorPropiedades.Dominio.Modelos;
using AppGestorPropiedades.Dominio.Entidades;
using AutoMapper;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;

namespace AppGestorPropiedades.Infraestructura.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class GestorPropiedadesController : ControllerBase
    {


        public readonly IGestorPropiedadesUseCase useCasePropiedades;
        private readonly IMapper mapper;
        public GestorPropiedadesController(IGestorPropiedadesUseCase _useCasePropiedades, IMapper _mapper)
        {
            useCasePropiedades = _useCasePropiedades;
            mapper = _mapper;
        }

        [HttpGet]
     
        public List<PropiedadesDTO> ListarPropiedades(int precioMin, int precioMax)
        {
            var result = new List<PropiedadesDTO>();
            try
            {
                var propiedades = useCasePropiedades.Listar(precioMin, precioMax);
                if (propiedades.Any())
                {
                    result = mapper.Map<List<PropiedadesDTO>>(propiedades);
                    result[0].Mensaje = "La solicitud fué exitosa";
                }
                else {
                    result = new List<PropiedadesDTO>() {
                         new PropiedadesDTO()
                         {
                            Mensaje = "No hay propiedades registradas"
                         }
                    };
                }
            }
            catch (Exception e)
            {
                result[0].Mensaje = $"Ocurrió un error al realizar la solicitud: {e.Message}";
                throw;
            }
            return result;
        }
        [HttpPost(Name = "RegistroPropiedades")]
        public IActionResult RegistroPropiedades(PropiedadesDTO datos)
        {
            var result = new List<PropiedadesDTO>();
            try
            {
                var datosModels = mapper.Map<PropiedadesModelos>(datos);
                var propiedades = useCasePropiedades.Agregar(datosModels);
                if (!string.IsNullOrEmpty(propiedades.Mensaje))
                {
                    return BadRequest(propiedades.Mensaje);
                }
                return Ok(new
                {
                    Exito = true,
                    Mensaje = "Propiedad registrada exitosamente"
                });
            }
            catch (Exception e)
            {
                return BadRequest($"Ocurrió un error al registrar la propiedad: {e.Message}");
            }
        }

        [HttpDelete(Name = "EliminarPropiedades")]
        public IActionResult EliminarPropiedades(int id)
        {
            try
            {
                var propiedades = useCasePropiedades.Eliminar(id);
                if (!string.IsNullOrEmpty(propiedades.Mensaje))
                {
                    return BadRequest(propiedades.Mensaje);
                }
                return Ok(new
                {
                    Exito = true,
                    Mensaje = "Propiedad eliminada exitosamente"
                });
            }
            catch (Exception e)
            {
                return BadRequest($"Ocurrió un error al eliminar la propiedad: {e.Message}");
            }
        }

        [HttpPost(Name = "ArrendarPropiedades")]
        public IActionResult ArrendarPropiedades(PropiedadesDTO datos)
        {
            try
            {
                var datosModels = mapper.Map<PropiedadesModelos>(datos);
                useCasePropiedades.Arrendar(datosModels);
                return Ok(new{
                    Exito = true,
                    Mensaje = "Propiedad arrendada exitosamente"
                });
            }
            catch (Exception e)
            {
                return BadRequest($"Ocurrió un error al arrendar la propiedad: {e.Message}");
            }
        }

        [HttpPut(Name = "EditarPropiedades")]
        public IActionResult EditarPropiedades(PropiedadesDTO datos)
        {
            try
            {
                var datosModels = mapper.Map<PropiedadesModelos>(datos);
                
                useCasePropiedades.Editar(datosModels);

                return Ok(new
                {
                    Exito = true,
                    Mensaje = "Propiedad editada exitosamente"
                });
            }
            catch (Exception e)
            {
                return BadRequest($"Ocurrió un error al registrar la propiedad: {e.Message}");
            }
        }
    }
}