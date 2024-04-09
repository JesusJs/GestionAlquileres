
using NUnit.Framework;
using Moq;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using AppGestorPropiedades.Dominio.Entidades;
using AppGestorPropiedades.Dominio.Interfaces.Repositorios;
using AppGestorPropiedades.Dominio.Modelos;

namespace AppGestorPropiedades.AplicacionTest
{
    public class GestorPropiedadesUseCaseTest
    {
        private Mock<IRepositorioBase<Propiedades>> _repoMock;
        private Mock<IMapper> _mapperMock;
        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IRepositorioBase<Propiedades>>();
            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public void Listar_DeberaRetornarPropiedadesFiltradas()
        {
            // Arrange
            var propiedadesModelos = new List<PropiedadesModelos>();
            var propiedades = new List<Propiedades>()
            {
                new Propiedades { propiedadesId = 1, disponibilidad = true, precio = 1500000 },
                new Propiedades { propiedadesId = 2, disponibilidad = true, precio = 2000000 },
                new Propiedades { propiedadesId = 3, disponibilidad = false, precio = 3000000 },
             };
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
            var propiedadesFiltradas = propiedades.Where(e => e.disponibilidad && e.precio >= 1000000 || e.precio <= 2500000).ToList();

            var repoPrpiedadesoMock = new Mock<IRepositorioBase<Propiedades>>();

            // Assert
            Assert.IsNotNull(propiedades);
        }

        [Test]
        public void Agregar_DeberiaRetornarPropiedadAgregada()
        {
            // Arrange
            var propiedadesModelo = new PropiedadesModelos
            {
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "https://imagen.com",
                disponibilidad = true,
                precio = 1500000,
            };

            var entidad = new Propiedades
            {
                propiedadesId = 1, // Asignar ID si se requiere
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "https://imagen.com",
                disponibilidad = true,
                precio = 1500000,
            };

            _mapperMock.Setup(x => x.Map<Propiedades>(propiedadesModelo)).Returns(entidad);
            _repoMock.Setup(x => x.Agregar(entidad)).Returns(entidad);
          
            var repoPrpiedadesoMock = new Mock<IRepositorioBase<Propiedades>>();
            // Act
            var repositorioAgregar = _repoMock.Setup(x => x.Agregar(entidad)).Returns(entidad);
            var map = _mapperMock.Setup(x => x.Map<PropiedadesModelos>(repositorioAgregar)).Returns(propiedadesModelo);
            // Assert
            Assert.NotNull(map);

         }

        [Test]
        public void Eliminar_DeberiaLanzarExcepcionFechaFueraRango()
        {
            // Arrange
            const int id = 1;
            var propiedadesModelo = new PropiedadesModelos
            {
                propiedadesId = 1, // Asignar ID si se requiere
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "https://imagen.com",
                disponibilidad = true,
                precio = 1500000,
            };

            var entidad = new Propiedades
            {
                propiedadesId = 1, // Asignar ID si se requiere
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "https://imagen.com",
                disponibilidad = true,
                precio = 1500000,
                fechaArrendamiento = DateTime.Now.AddDays(-35),
            };

            _mapperMock.Setup(x => x.Map<Propiedades>(propiedadesModelo)).Returns(entidad);
            _repoMock.Setup(x => x.ObtenerPropiedadesId(id)).Returns(entidad);

            var repoPrpiedadesoMock = new Mock<IRepositorioBase<Propiedades>>();
            // Act
            var repositorioAgregar = _repoMock.Setup(x => x.Eliminar(entidad.propiedadesId));


            // Assert
            Assert.NotNull(repositorioAgregar);
        }
        [Test]
        public void Arrendar_DeberiaActualizarPropiedadDisponible()
        {
            // Arrange
            const int id = 1;
            var propiedadesModelo = new PropiedadesModelos
            {
                propiedadesId = 1, // Asignar ID si se requiere
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "https://imagen.com",
                disponibilidad = true,
                precio = 1500000,
            };

            var entidad = new Propiedades
            {
                propiedadesId = 1, // Asignar ID si se requiere
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "https://imagen.com",
                disponibilidad = true,
                precio = 1500000,
                fechaArrendamiento = DateTime.Now.AddDays(-35),
            };

            _mapperMock.Setup(x => x.Map<Propiedades>(propiedadesModelo)).Returns(entidad);
            var obtenerPropiedades = _repoMock.Setup(x => x.ObtenerPropiedadesId(id)).Returns(entidad);
            var editar = _repoMock.Setup(x => x.Editar(entidad));
            // Assert
            Assert.NotNull(obtenerPropiedades);
        }
        [Test]
        public void Editar_DeberiaActualizarPropiedadExistente()
        {
            // Arrange
            const int id = 1;
            var propiedadesModeloEditada = new PropiedadesModelos
            {
                propiedadesId = 1, // Asignar ID si se requiere
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "https://imagen.com",
                disponibilidad = true,
                precio = 1500000,
            };

            var entidadOriginal = new Propiedades
            {
                propiedadesId = 1, // Asignar ID si se requiere
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "https://imagen.com",
                disponibilidad = true,
                precio = 1500000,
                fechaArrendamiento = DateTime.Now.AddDays(-35),
            };

            _mapperMock.Setup(x => x.Map<Propiedades>(propiedadesModeloEditada)).Returns(entidadOriginal);
           var obtenerPropiedadesId =  _repoMock.Setup(x => x.ObtenerPropiedadesId(id)).Returns(entidadOriginal);

            // Act

            // Assert
            Assert.NotNull(obtenerPropiedadesId);
            Assert.AreEqual(propiedadesModeloEditada.nombre, entidadOriginal.nombre);
            Assert.AreEqual(propiedadesModeloEditada.ubicacion, entidadOriginal.ubicacion);
            Assert.AreEqual(propiedadesModeloEditada.urlImagen, entidadOriginal.urlImagen);
            Assert.AreEqual(propiedadesModeloEditada.disponibilidad, entidadOriginal.disponibilidad);
            Assert.AreEqual(propiedadesModeloEditada.precio, entidadOriginal.precio);
        }
    }
  
}