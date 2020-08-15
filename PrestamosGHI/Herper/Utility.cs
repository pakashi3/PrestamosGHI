using PrestamosGHI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamosGHI.Herper
{
    public static class Utility
    {

        public static List<CalculoList> GetCalculoLists(string guid, decimal prestamo, int plazo)
        {
            //var prestamo = $("#<%=Cliente.MontoPrestamo%>");
            decimal interesporcentaje = 0.3m;

            decimal saldo = prestamo;
            decimal interes = 0;
            decimal cuotamensual = ((prestamo * (interesporcentaje) + prestamo) / plazo);
            var capital = 0;


            var list = new List<CalculoList>();

            for (int i = 1; i <= plazo; i++)
            {
                list.Add(new CalculoList
                {
                    GuiId = guid,
                    NroCuota = i,
                    Capital = cuotamensual - interes,
                    Interes = (prestamo * 0.3m) / 12,
                    cuotaMensual = cuotamensual,
                    Pendiente = saldo - capital,

                });
            }

            return list;
        }
    }
}
