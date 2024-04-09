using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorPropiedades.Infraestructura.Datos.DTO
{
    public class PropiedadesDTO
    {
        public int propiedadesId { get; set; }
        public string nombre { get; set; }
        public string ubicacion { get; set; }
        public string urlImagen { get; set; }
        public bool disponibilidad { get; set; }
        public int precio { get; set; }
        public DateTime fechaArrendamiento { get; set; }
        public string Mensaje { get; set; }
    }
}
