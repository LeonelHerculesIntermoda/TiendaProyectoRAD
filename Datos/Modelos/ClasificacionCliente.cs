using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class ClasificacionCliente:EntidadBase
    {
        [Key]
        public int ClasificacionClienteId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(150)]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
