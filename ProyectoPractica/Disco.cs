using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPractica
{
    internal class Disco
    {
        public int IdDisco { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int CantidadCanciones { get; set; }
        public string UrlImagenTapa { get; set; }
        public int IdEstilo { get; set; }
        public int IdEdicion { get; set; }
    }
}
