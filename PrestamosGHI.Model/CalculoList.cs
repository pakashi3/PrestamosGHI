using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace PrestamosGHI.Model
{
    public class CalculoList
    {
     
        public string GuiId { get; set; }
        public string PrestamoGuiId { get; set; }

        [Key]
        public int Id { get; set; }
        public int NroCuota { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Capital { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Interes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal cuotaMensual { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Pendiente { get; set; }

        public int Estado { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoPagado { get; set; }



    }
}
