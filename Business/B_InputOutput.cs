using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using System.Linq;
using Entities;

namespace Business
{
    public class B_InputOutput
    {
        public List<InputOutputEntity> InputOuputList()
        {
            using (var db = new InventaryContext())
            {
                return db.InOuts.ToList();
            }
        }


        public void CreateCategory(InputOutputEntity oInputOutput)
        {
            using (var db = new InventaryContext())
            {
                db.InOuts.Add(oInputOutput);
                db.SaveChanges();
            }

        }

        public void UpdateCategory(InputOutputEntity oInputOutput)
        {
            using (var db = new InventaryContext())
            {
                db.InOuts.Update(oInputOutput);
                db.SaveChanges();
            }
        }





    }
}
