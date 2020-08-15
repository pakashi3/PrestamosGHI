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
    public class AprobacionModel : PageModel
    {
        private EFClientesService service;
        private EFCalculoList _calculoLService;
        private EFPrestamosService _prestamoService;

        [BindProperty]
        public Cliente Cliente { get; set; }

        [BindProperty]
        public CalculoList CalculoList { get; set; }

        [BindProperty]
        public Prestamo Prestamo { get; set; }

        public AprobacionModel(EFClientesService service, EFCalculoList service1, EFPrestamosService service2)
        {
            this.service = service;
            this._calculoLService = service1;
            this._prestamoService = service2;

        }
        public void OnGet(int? Id)
        {
            if (Id.HasValue)
            {

                Cliente = service.GetClientesPorId(Id.Value);
                Cliente.CalculoList = _calculoLService.GetAll()
                    .Where(x => x.GuiId == Cliente.GuiId);

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

                var cliente = service.GetAll().FirstOrDefault( x=> x.GuiId == Cliente.GuiId );

                if (Cliente.AprobadaRechasada)
                    cliente.Estatus = 2;
                else
                {
                    cliente.Estatus = 3;
                    Cliente = service.ActualizarCliente(cliente);
                    service.GuardarCambios();

                    return RedirectToPage("./EstatusPrestamo");
                }

                Cliente = service.ActualizarCliente(cliente);

                var guid = new Guid().ToString();


                var list = _calculoLService.GetAll()
                     .Where(x => x.GuiId == Cliente.GuiId);

                foreach (var item in list)
                {
                    item.Estado = 1;
                    item.PrestamoGuiId = guid;
                }

                _calculoLService.UpdateAll(list);



                _prestamoService.Create(new Prestamo
                {
                    guidSolicitud = cliente.GuiId,
                    guid = guid,
                });

                service.GuardarCambios();
                return RedirectToPage("./EstatusPrestamo");
            }
            return Page();
        }

    }
}
