using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PrestamosGHI.Model
{
    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }

        public string guid { get; set; }
        public string guidSolicitud { get; set; }

        public int ClienteId { get; set; }

        [Display(Name = "Ingrese Nombre de usuario")]
        public int Usuario { get; set; }

        public DateTime Fprestamo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Interes { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Saldo { get; set; }

        [MinLength(15)]
        [MaxLength(255)]
        public string FormaPago { get; set; }

        public DateTime Fpago { get; set; }

        public DateTime Plazo { get; set; }
        public Pago Pago { get; set; }
        public IEnumerable<CalculoList> CalculoList { get; set; } = new List<CalculoList>();

    }
}
