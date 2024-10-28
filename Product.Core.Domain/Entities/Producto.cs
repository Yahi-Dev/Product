using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Domain.Entities
{
    public class Producto
    {
        public virtual int ProductID { get; set; }

        [MaxLength(250)]
        [Required]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}
