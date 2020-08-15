using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrestamosGHI.Data;
using PrestamosGHI.Model;

namespace PrestamosGHI.Pages
{
    public class EstatusPrestamoModel : PageModel
    {
        public EFPrestamosService _prestamosService;

        [BindProperty]
        public Prestamo Prestamo { get; set; }
        public IList<Prestamo> prestamoList { get; set; }

        public EstatusPrestamoModel(EFPrestamosService prestamoService)
        {
            this._prestamosService = prestamoService;
        }


        public void OnGet(string Id)
        {
            //restamoList = _prestamosService.GetAll().ToList();
            prestamoList = new List<Prestamo>{

                new Prestamo {
                Saldo = 324554M,
               IdPrestamo = 35212,
               guid = new Guid().ToString()
                }
            };
        }
            
            

    }
}
