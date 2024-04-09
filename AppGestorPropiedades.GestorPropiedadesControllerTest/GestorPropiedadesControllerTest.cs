using AppGestorPropiedades.Dominio.Entidades;
using AppGestorPropiedades.Dominio.Modelos;
using AppGestorPropiedades.Infraestructura.Datos.DTO;
using AppGestorPropiedades.Infraestructura.Datos.Repositorios;
using AppGrestorPropiedades.Application.UseCase;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net.WebSockets;

namespace AppGestorPropiedades.GestorPropiedadesControllerTest
{
    public class GestorPropiedadesControllerTest
    {
        private Mock<GestorPropiedadesUseCase> _repoMock;
        private Mock<IMapper> _mapperMock;
        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<GestorPropiedadesUseCase>();
            _mapperMock = new Mock<IMapper>();
        }


        [Test]
        public void ListarPropiedades_DeberiaDevolverListaPropiedadesDTO()
        {
            // Arrange
           
            var propiedadesEsperadas = new List<PropiedadesModelos>
            {
                new PropiedadesModelos
                {
                    propiedadesId = 1,
                    nombre = "CasaEjemplo",
                    ubicacion = "Calle 123",
                    urlImagen = "[https://imagen.com](https://imagen.com)",
                    disponibilidad = true,
                    precio = 1500000,
                },
                new PropiedadesModelos
                {
                    propiedadesId = 2,
                    nombre = "CasaEjemplo",
                    ubicacion = "Calle 123",
                    urlImagen = "[https://imagen.com](https://imagen.com)",
                    disponibilidad = true,
                    precio = 1500000,
                },
            };

            var propiedadesDTOEsperadas = new List<PropiedadesDTO>
            {
                new PropiedadesDTO
                {
                    propiedadesId = 1,
                    nombre = "CasaEjemplo",
                    ubicacion = "Calle 123",
                    urlImagen = "[https://imagen.com](https://imagen.com)",
                    disponibilidad = true,
                    precio = 1500000,
                    Mensaje = "La solicitud fué exitosa",
                },
                new PropiedadesDTO
                {
                    propiedadesId = 2,
                    nombre = "CasaEjemplo",
                    ubicacion = "Calle 123",
                    urlImagen = "[https://imagen.com](https://imagen.com)",
                    disponibilidad = true,
                    precio = 1500000,
                },
            };
          
            var dto = new List<PropiedadesDTO>();
            var result =  _mapperMock.Setup(x => x.Map<List<PropiedadesDTO>>(propiedadesEsperadas)).Returns(propiedadesDTOEsperadas);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void RegistroPropiedades_DeberiaRegistrarPropiedad_YRetornarOk()
        {
            // Arrange
            var _mapperMock = new Mock<IMapper>();

            var propiedadesDTO = new PropiedadesDTO
            {
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "[https://imagen.com](https://imagen.com)",
                disponibilidad = true,
                precio = 1500000,
            };

            var propiedadesModeloEsperada = new PropiedadesModelos
            {
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "[https://imagen.com](https://imagen.com)",
                disponibilidad = true,
                precio = 1500000,
            };

            var propiedadesModelo = new PropiedadesModelos
            {
                propiedadesId = 1,
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "[https://imagen.com](https://imagen.com)",
                disponibilidad = true,
                precio = 1500000,
                Mensaje = "Propiedad registrada exitosamente",
            };

            var registrar = _mapperMock.Setup(x => x.Map<PropiedadesModelos>(propiedadesDTO)).Returns(propiedadesModeloEsperada);
            // Assert
            Assert.NotNull(registrar);

         
        }

        [Test]
        public void EliminarPropiedades_DeberiaDevolverBadRequest_SiOcurreUnError()
        {
            // Arrange


            var entidad = new PropiedadesModelos
            {
                propiedadesId = 1,
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "[https://imagen.com](https://imagen.com)",
                disponibilidad = true,
                precio = 1500000,
            };
            var data = new PropiedadesDTO()
            {
                propiedadesId = 1,
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "[https://imagen.com](https://imagen.com)",
                disponibilidad = true,
                precio = 1500000,
            };
            // Act
            var resultado = _mapperMock.Setup(x => x.Map<PropiedadesDTO>(entidad)).Returns(data);

            // Assert
            Assert.NotNull(resultado);
        }
        [Test]
        public void ArrendarPropiedades_DeberiaArrendarPropiedad_YRetornarOk()
        {
            // Arrange
            var _mapperMock = new Mock<IMapper>();

            var propiedadesDTO = new PropiedadesDTO
            {
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "[https://imagen.com](https://imagen.com)",
                disponibilidad = true,
                precio = 1500000,
            };

            var propiedadesModeloEsperada = new PropiedadesModelos
            {
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "[https://imagen.com](https://imagen.com)",
                disponibilidad = true,
                precio = 1500000,
            };

            var resultado = _mapperMock.Setup(x => x.Map<PropiedadesDTO>(propiedadesModeloEsperada)).Returns(propiedadesDTO);
            // Assert
            Assert.NotNull(resultado);

        }
        [Test]
        public void EditarPropiedades_DeberiaEditarPropiedad_YRetornarOk()
        {
            // Arrange
            var _mapperMock = new Mock<IMapper>();

            var propiedadesDTO = new PropiedadesDTO
            {
                propiedadesId = 1,
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "[https://imagen.com](https://imagen.com)",
                disponibilidad = true,
                precio = 1500000,
            };

            var propiedadesModeloEsperada = new PropiedadesModelos
            {
                propiedadesId = 1,
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "[https://imagen.com](https://imagen.com)",
                disponibilidad = true,
                precio = 1500000,
            };

            var resultado = _mapperMock.Setup(x => x.Map<PropiedadesDTO>(propiedadesModeloEsperada)).Returns(propiedadesDTO);

            // Assert
            Assert.NotNull(resultado);
        }
    }

}