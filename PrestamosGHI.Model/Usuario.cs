using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrestamosGHI.Model
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public String Login { get; set; }

        public String Password { get; set; }

        public String Rol { get; set; }
    }
}
