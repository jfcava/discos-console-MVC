using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disco
    {
        public int Id { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        [DisplayName("Cantidad de Canciones")]
        public int CantidadCanciones { get; set; }
        [DisplayName("Imagen Tapa")]
        public string UrlTapa { get; set; }
        public Estilo Estilo { get; set; }
        public TipoEdicion TipoEdicion { get; set; }
    }
}
