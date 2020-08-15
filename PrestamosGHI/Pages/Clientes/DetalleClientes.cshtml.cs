using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrestamosGHI.Data;
using PrestamosGHI.Model;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PrestamosGHI.Pages.Clientes
{
    public class DetalleClientesModel : PageModel
    {
        private EFClientesService service;

        public Cliente Cliente { get; set; }

        public DetalleClientesModel(EFClientesService service)
        {
            this.service = service;
        }


        public ActionResult OnGet(int Id)
        {
            Cliente = service.GetClientesPorId(Id);

            if (Cliente == null)
            {
                return RedirectToPage("ClienteNoEncontrado");
            }
            else 
            {
                return Page();
            }
        }
    }
}
