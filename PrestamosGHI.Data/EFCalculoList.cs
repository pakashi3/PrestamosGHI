using PrestamosGHI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestamosGHI.Data
{
    public class EFCalculoList
    {
        private PrestamosGHIContext db;

        public EFCalculoList(PrestamosGHIContext db)
        {
            this.db = db;
        }

        public IEnumerable<CalculoList> GetAll()
        {
            return db.CalculoLists.ToList();
        }

        public CalculoList CrearCalculoList(CalculoList calculoList)
        {
            db.CalculoLists.Add(calculoList);
            return calculoList;
        }

        public void UpdateAll(IEnumerable<CalculoList> calculoList)
        {
            db.CalculoLists.UpdateRange(calculoList);
        }
    }
}
