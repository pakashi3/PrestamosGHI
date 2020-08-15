using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrestamosGHI.Data;
using PrestamosGHI.Model;

namespace PrestamosGHI.Pages.Clientes
{
    public class EditarModel : PageModel
    {
        private EFClientesService service;
        private IHtmlHelper helper;
        private EFCalculoList _calculoLService;
        private EFPrestamosService _prestamoService;

        [BindProperty]
        public Cliente Cliente { get; set; }

        [BindProperty]
        public CalculoList CalculoList { get; set; }
        
        [BindProperty]
        public Prestamo Prestamo { get; set; }

        public EditarModel(EFClientesService service, EFCalculoList service1, EFPrestamosService service2, IHtmlHelper helper)
        {
            this.service = service;
            this._calculoLService = service1;
            this._prestamoService = service2;

            this.helper = helper;
        }
        public void OnGet(int? Id)
        {
            if (Id.HasValue)
            {
              
                Cliente = service.GetClientesPorId(Id.Value);
                Cliente.CalculoList = _calculoLService.GetAll()
                    .Where( x=> x.GuiId == Cliente.GuiId);

            }
            else
            {
                Cliente = new Cliente();
            }
        }

        public ActionResult OnPost()
        {
         
                if (ModelState.IsValid)
                {
                var guid = new Guid().ToString();

                if (Cliente.Id == 0)
                    {

                    var list = PrestamosGHI.Herper.Utility.GetCalculoLists(guid, Cliente.MontoPrestamo, Cliente.Plazo);
                    Cliente.GuiId = guid;
                    Cliente.Estatus = 1;

                    foreach (var item in list)
                        _calculoLService.CrearCalculoList(item);

                        Cliente = service.CrearCliente(Cliente);
                        TempData["Mensaje"] = "Registro Creado Correctamente";
                    }
                    else
                    {
                        Cliente = service.ActualizarCliente(Cliente);
                        TempData["Mensaje"] = "Registro Actualizado Correctamente";
                    }

                    service.GuardarCambios();
                    return RedirectToPage("./DetalleClientes", new { Id = Cliente.Id });
                }
                return Page();
 
        }

     
        //public IActionResult OnPostCaculo([FromBody] Carculo model)
        //{

        //    return new JsonResult("OnPostGeoLocation CALLED ####################################");
        //}
    }

  
}
   
