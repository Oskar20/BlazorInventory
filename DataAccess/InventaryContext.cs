using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class InventaryContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<InputOutputEntity> InOuts { get; set; }
        public  DbSet<WareHouseEntity> Warehouses { get; set; }   
        public DbSet<StorageEntity> Storages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured)
            {
                options.UseSqlServer("Server=TuServidor;Database=InventoryDb;User Id=TuUsuario; Password=TuContraseña");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryEntity>().HasData(
                
                new CategoryEntity { CategoryId = "ASH", CategoryNmae="Aseo Hogar"},
                new CategoryEntity { CategoryId = "ASP", CategoryNmae = "Aseo Personal" },
                new CategoryEntity { CategoryId = "HGR", CategoryNmae = "Hogar" },
                new CategoryEntity { CategoryId = "PRF", CategoryNmae = "Perfumería" },
                new CategoryEntity { CategoryId = "SLD", CategoryNmae = "Salud" },
                new CategoryEntity { CategoryId = "VDJ", CategoryNmae = "Video Juegos" }

                );

            modelBuilder.Entity<WareHouseEntity>().HasData(
               new WareHouseEntity { WareHouseId = Guid.NewGuid().ToString(), WareHouseName = "Bodega Central", WareHouseAddress = "Calle 8 con 23" },
               new WareHouseEntity { WareHouseId = Guid.NewGuid().ToString(), WareHouseName = "Bodega Norte", WareHouseAddress = "Calle norte con occidente" }
               );

            modelBuilder.Entity<ProductEntity>().HasData(
               new ProductEntity { ProductId = "ASJ-98745", ProductName = "Crema para manos marca Tersa", ProductDescription = "", CategoryId = "PRF" },
               new ProductEntity { ProductId = "RPT-546587", ProductName = "Pastillas para la garganta LESUS", ProductDescription = "", CategoryId = "SLD" }
               );
        }
    }
}
