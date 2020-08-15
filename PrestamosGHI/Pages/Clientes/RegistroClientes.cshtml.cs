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
      
    public class RegistroClientesModel : PageModel
    { 
    public EFClientesService ClienteService;
    
   [BindProperty(SupportsGet = true)]
        public string Texto { get; set; }

        [TempData]
        public string MensajeEliminacion { get; set; }

        public IList<Cliente> Clientes { get; set; }


    public RegistroClientesModel(EFClientesService clienteService)
    {

            ClienteService = clienteService;
    }
    public void OnGet()
    {
        
        this.Clientes = ClienteService.GetClientesPorNombre(Texto);
    }
        [HttpPost]
        public void OnCaculo(decimal Tasa, decimal monto,int duracion)
        {

            this.Clientes = ClienteService.GetClientesPorNombre(Texto);
        }

        //public IActionResult OnPost([FromBody] Carculo model)
        //{
        //    // Just to test that it actually gets called
        //    Console.WriteLine("OnPostGeoLocation CALLED ####################################");

        //    return new JsonResult("OnPostGeoLocation CALLED ####################################");
        //}
    }

    //public class Carculo
    //{
    //    public int Tasa { get; set; }
    //    public int monto { get; set; }
    //    public int duracion { get; set; }
    //}
}
