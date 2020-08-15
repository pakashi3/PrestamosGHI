using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PrestamosGHI.Model
{
    public class Pago
    {
        [Key]
        public int IdPago { get; set; }

        public int PrestamoId { get; set; }

        public DateTime Fecha { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cuota { get; set; }
        public Gasto Gasto { get; set; }

    }
}
