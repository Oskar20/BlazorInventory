using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class B_Storage
    {

        public static List<StorageEntity> StorageList()
        {
            using(var db = new InventaryContext())
            {
                return db.Storages
                     .Include(s => s.Product)
                     .Include(s => s.Warehouse)
                     .ToList();
            }
        }


        public static StorageEntity CreateStorage(StorageEntity oStorage)
        {
            using (var db = new InventaryContext())
            {
                db.Storages.Add(oStorage);
                db.SaveChanges();

                return GetStorageById(oStorage.StorageId);
            }
        }

        /* NUEVO MÉTODO */
        public static StorageEntity GetStorageById(string id)
        {
            using (var db = new InventaryContext())
            {
                return db.Storages
                    .Include(s => s.Product)
                    .Include(s => s.Warehouse)
                    .ToList()
                    .LastOrDefault(s => s.StorageId == id);
            }
        }

        /* NUEVO MÉTODO */
        public static bool IsProductInWarehouse(string idStorage)
        {
            using (var db = new InventaryContext())
            {
                var product = db.Storages.ToList()
                    .Where(p => p.StorageId == idStorage);

                return product.Any();
            }
        }


        /* NUEVO MÉTODO */
        public static List<StorageEntity> StorageListByWarehouse(string idWarehouse)
        {
            using (var db = new InventaryContext())
            {
                return db.Storages
                    .Include(s => s.Product)
                    .Include(s => s.Warehouse)
                    .Where(s => s.WarehouseId == idWarehouse)
                    .ToList();
            }
        }

        public static void UpdateStorage(StorageEntity oStorage)
        {
            using ( var db = new InventaryContext())
            {
                db.Storages.Update(oStorage);
                db.SaveChanges();
            }
        }

    }
}
