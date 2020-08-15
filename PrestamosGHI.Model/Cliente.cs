using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PrestamosGHI.Model
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string GuiId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [Display(Name = "Ingrese su Nombre")]
        public string Nombre { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [Display(Name = "Ingrese su Apellido")]
        public string Apellido { get; set; }

        [Display(Name = "Ingrese su Cedula")]
        [MinLength(5)]
        [MaxLength(15)]
        public string Cedula { get; set; }
        [Display(Name = "Ingrese su Direccion")]

        [MinLength(5)]
        [MaxLength(15)]
        public string Direccion { get; set; }

        [Display(Name = "Ingrese su numero de Telefono")]
        [MinLength(10)]
        [MaxLength(15)]
        public string Telefono { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoPrestamo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal  IngresoNeto { get; set; }
        //public decimal  Tasa { get; set; }

        public int Plazo { get; set; }
        public DateTime Fprestamo { get; set; }
        public int Estatus { get; set; }
        public bool AprobadaRechasada { get; set; }

        public Prestamo Prestamo { get; set; }
        public IEnumerable<CalculoList> CalculoList { get; set; } = new List<CalculoList>();

    }
}
