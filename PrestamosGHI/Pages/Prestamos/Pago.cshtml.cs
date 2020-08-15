using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrestamosGHI.Data;
using PrestamosGHI.Model;

namespace PrestamosGHI.Pages.Clientes
{
    public class PagoModel : PageModel
    {

        public EFPrestamosService _prestamosService;
        private EFCalculoList _calculoLService;

        [BindProperty]
        public Prestamo model { get; set; } 
        public CalculoList CalculoList { get; set; }

        public PagoModel(EFPrestamosService prestamoService, EFCalculoList service1)
        {
            this._prestamosService = prestamoService;
            this._calculoLService = service1;

        }
        public void OnGet(string id)
        {

            //model = _prestamosService.GetById(id);
            //model.CalculoList = _calculoLService.GetAll()
            //    .Where(x => x.PrestamoGuiId == id);



            model = new Prestamo();

            model.CalculoList = new List<CalculoList> { new CalculoList { GuiId = new Guid().ToString(), NroCuota = 1, PrestamoGuiId = new Guid().ToString(), MontoPagado = 20 } };
        }
        public void OnPost()
        {

        
        }


    }
}
