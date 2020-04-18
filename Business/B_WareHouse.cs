using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using System.Linq;
using Entities;

namespace Business
{
    public class B_WareHouse
    {

        public static List<WareHouseEntity> WareHouseList()
        {
            using (var db = new InventaryContext())
            {
                return db.Warehouses.ToList();
            }
        }


        public static WareHouseEntity WareHouseById(string id)
        {
            using (var db = new InventaryContext())
            {
                return db.Warehouses.ToList().LastOrDefault( w => w.WareHouseId == id);
            }
        }

        public static void CreateWareHouse(WareHouseEntity oWareHouse)
        {
            using( var db = new InventaryContext())
            {
                db.Warehouses.Add(oWareHouse);
                db.SaveChanges();

            }
        }

        public static void UpdateWareHouse(WareHouseEntity oWareHouse)
        {
            using (var db = new InventaryContext())
            {
                db.Warehouses.Update(oWareHouse);
                db.SaveChanges();
            }
        }


    }
}
