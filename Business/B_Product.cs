﻿using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using System.Linq;
using Entities;

namespace Business
{
    public class B_Product
    {

        public static List<ProductEntity> ProductList()
        {
            using (var db = new InventaryContext())
            {
                return db.Products.ToList();
            }
        }


        public static ProductEntity ProductById(string id)
        {
            using (var db = new InventaryContext())
            {
                return db.Products.ToList().LastOrDefault(p => p.ProductId == id);
            }
        }

        public static void CreateProduct(ProductEntity oProduct)
        {
            using (var db = new InventaryContext())
            {
                db.Products.Add(oProduct);
                db.SaveChanges();
            }
        }

        public static void UpdateProduct(ProductEntity oProduct)
        {
            using(var db = new InventaryContext())
            {
                db.Products.Update(oProduct);
                db.SaveChanges();
            }
        }

    }
}
