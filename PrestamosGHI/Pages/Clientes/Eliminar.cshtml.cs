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
    public class EliminarModel : PageModel
    {
        private EFClientesService service;

        public Cliente Cliente { get; set; }
        public EliminarModel(EFClientesService service)
        {
            this.service = service;
        }

        public void OnGet(int Id)
        {
            this.Cliente = service.GetClientesPorId(Id);
        }
        public ActionResult OnPost(int Id)
        {
            var Cliente = service.Eliminar(Id);
            service.GuardarCambios();

            TempData["MensajeEliminacion"] = $"Se ha eliminado el cliente{Cliente.Nombre}";
            return RedirectToPage("./RegistroClientes");

        }
    }
}
