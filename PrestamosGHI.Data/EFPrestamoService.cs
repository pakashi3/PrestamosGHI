using PrestamosGHI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PrestamosGHI.Data
{
    public class EFPrestamosService
    {
        private PrestamosGHIContext db;

        public EFPrestamosService(PrestamosGHIContext db)
        {
            this.db = db;
        }

        public Prestamo GetById( string id)
        {
            return db.Prestamos.Single( x => x.guid == id);
        }
        public IEnumerable<Prestamo> GetAll()
        {
            return db.Prestamos.ToList();
        }

        public void Create(Prestamo model)
        {
            db.Prestamos.Add(model);
        }
    }
}
