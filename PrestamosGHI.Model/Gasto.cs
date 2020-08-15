using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrestamosGHI.Model
{
    public class Gasto
    {
        [Key]
        public int Id { get; set; }


        public int PagoId { get; set; }

        public DateTime Fecha { get; set; }
        [Display(Name = "Ingrese Concepto de Pago")]
        public string Concepto { get; set; }
    }
}
