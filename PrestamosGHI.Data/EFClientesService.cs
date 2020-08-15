using PrestamosGHI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestamosGHI.Data
{
    public class EFClientesService
    {
        private PrestamosGHIContext db;

        public EFClientesService(PrestamosGHIContext db)
        {
            this.db = db;
        }

        public Cliente ActualizarCliente(Cliente clienteActualizado)
        {
            var ClienteExistente = db.Clientes.SingleOrDefault(c => c.Id == clienteActualizado.Id);

            ClienteExistente.Nombre = clienteActualizado.Nombre;
            ClienteExistente.Apellido = clienteActualizado.Apellido;
            ClienteExistente.Cedula = clienteActualizado.Cedula;
            ClienteExistente.Direccion = clienteActualizado.Direccion;
            ClienteExistente.Telefono = clienteActualizado.Telefono;
            ClienteExistente.IngresoNeto = clienteActualizado.IngresoNeto;

            return ClienteExistente;
        }

        public Cliente Eliminar(int Id)
        {
            var cliente = db.Clientes.Single(c => c.Id == Id);
            db.Clientes.Remove(cliente);

            return cliente;
        }

        public Cliente CrearCliente(Cliente cliente)
        {
            var model = db.Clientes.Add(cliente);
            return cliente;
        }

        public Cliente GetClientesPorId(int Id)
        {
            return db.Clientes.SingleOrDefault(d => d.Id == Id);
        }


        public IList<Cliente> GetClientesPorNombre(string texto)
        {
            if (!string.IsNullOrEmpty(texto))
            {
                texto = texto.ToLower();
            }
            return db.Clientes.Where(c => string.IsNullOrEmpty(texto) || c.Nombre.ToLower().Contains(texto)).OrderBy(c => c.Nombre).ToList();
        }

        public IEnumerable<Cliente> GetAll()
        {
            return db.Clientes.OrderByDescending(c => c.Id);
        }


        public int GuardarCambios()
        {
            return  db.SaveChanges();
        }

    
    }
}
