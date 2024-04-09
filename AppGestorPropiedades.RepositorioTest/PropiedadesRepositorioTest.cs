using AppGestorPropiedades.Dominio.Entidades;
using AppGestorPropiedades.Dominio.Interfaces.Repositorios;
using AppGestorPropiedades.Infraestructura.Datos.Contexto;
using AppGestorPropiedades.Infraestructura.Datos.Repositorios;
using AutoMapper;
using Moq;

namespace AppGestorPropiedades.RepositorioTest
{
    public class PropiedadesRepositorioTest
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
        public void Agregar_DeberiaAgregarPropiedadCorrectamente()
        {
            // Arrange
            var _propiedadesContexto = new PropiedadesContexto();
            var propiedad = new Propiedades
            {
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "[https://imagen.com](https://imagen.com)",
                disponibilidad = true,
                precio = 1500000,
            };

            // Act
            var resultado = _repoMock.Setup(x => x.Agregar(propiedad)).Returns(propiedad);

            // Assert
            Assert.NotNull(resultado);
        }
        [Test]
        public void Editar_DeberiaActualizarPropiedadExistente()
        {
            // Arrange
            var _propiedadesContexto = new PropiedadesContexto();
            var _repo = new PropiedadesRepositorio(_propiedadesContexto);
            var propiedadOriginal = new Propiedades
            {
                propiedadesId = 1,
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "[https://imagen.com](https://imagen.com)",
                disponibilidad = true,
                precio = 1500000,
            };

            var propiedadEditada = new Propiedades
            {
                propiedadesId = 1,
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "[https://imagen.com](https://imagen.com)",
                disponibilidad = true,
                precio = 1500000,
            };

           var obtenerPropiedadId = _repoMock.Setup(x => x.ObtenerPropiedadesId(propiedadEditada.propiedadesId)).Returns(propiedadOriginal);
           
            Assert.AreEqual(propiedadEditada.nombre, propiedadOriginal.nombre);
            Assert.AreEqual(propiedadEditada.ubicacion, propiedadOriginal.ubicacion);
            Assert.AreEqual(propiedadEditada.urlImagen, propiedadOriginal.urlImagen);
            Assert.AreEqual(propiedadEditada.disponibilidad, propiedadOriginal.disponibilidad);
            Assert.AreEqual(propiedadEditada.precio, propiedadOriginal.precio);
            // Assert
            Assert.NotNull(obtenerPropiedadId);

            
        }

        [Test]
        public void Eliminar_DeberiaEliminarPropiedadExistente()
        {
            // Arrange
            var _propiedadesContexto = new PropiedadesContexto();
            var _repo = new PropiedadesRepositorio(_propiedadesContexto);

            var propiedad = new Propiedades
            {
                propiedadesId = 1,
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "https://imagen.com",
                disponibilidad = true,
                precio = 1500000,
            };
            var _obtenerPropiedadId = _repoMock.Setup(x => x.ObtenerPropiedadesId(propiedad.propiedadesId)).Returns(propiedad);
            // Act
            _repoMock.Setup(x => x.Eliminar(propiedad.propiedadesId));
            // Assert
            Assert.IsNotNull(_obtenerPropiedadId);
        }

        [Test]
        public void Listar_DeberiaDevolverTodasLasPropiedades()
        {
            // Arrange
            var _propiedadesContexto = new PropiedadesContexto();
            var _repo = new PropiedadesRepositorio(_propiedadesContexto);

            var propiedadesEsperadas = new List<Propiedades>
            {
                new Propiedades
                {
                    propiedadesId = 1,
                   nombre = "CasaEjemplo",
                        ubicacion = "Calle 123",
                        urlImagen = "https://imagen.com",
                        disponibilidad = true,
                        precio = 1500000,
                },
                new Propiedades
                {
                    propiedadesId = 2,
                    nombre = "CasaEjemplo",
                        ubicacion = "Calle 123",
                        urlImagen = "https://imagen.com",
                        disponibilidad = true,
                        precio = 1500000,
                },
            };

            // Act

            var listar = _repoMock.Setup(x => x.Listar()).Returns(propiedadesEsperadas);

            // Assert
            Assert.IsNotNull(listar);

        }

        [Test]
        public void ObtenerPropiedadesId_DeberiaDevolverPropiedadCorrecta()
        {
            // Arrange
            var _propiedadesContexto = new PropiedadesContexto();
            var _repo = new PropiedadesRepositorio(_propiedadesContexto);
            var propiedades= new Propiedades();
            var propiedadEsperada = new Propiedades
            {
                propiedadesId = 1,
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "https://imagen.com",
                disponibilidad = true,
                precio = 1500000,
            };

            // Act
            var propiedadObtenida = _repoMock.Setup(x => x.ObtenerPropiedadesId(propiedadEsperada.propiedadesId)).Returns(propiedadEsperada);


            // Assert
            Assert.IsNotNull(propiedadObtenida);
        }

        [Test]
        public void Actualizar_DeberiaActualizarPropiedadExistente()
        {
            // Arrange
            var _propiedadesContexto = new PropiedadesContexto();
            var _repo = new PropiedadesRepositorio(_propiedadesContexto);

            var propiedadOriginal = new Propiedades
            {
                propiedadesId = 1,
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "https://imagen.com",
                disponibilidad = true,
                precio = 1500000,
            };

            var propiedadActualizada = new Propiedades
            {
                propiedadesId = 1,
                nombre = "CasaEjemplo",
                ubicacion = "Calle 123",
                urlImagen = "https://imagen.com",
                disponibilidad = true,
                precio = 1500000,
            };

            // Act
            var propiedadEditada = _repoMock.Setup(x => x.actualizar(propiedadOriginal)).Returns(propiedadActualizada);

            // Assert
            Assert.NotNull(propiedadEditada);
        }


    }
}