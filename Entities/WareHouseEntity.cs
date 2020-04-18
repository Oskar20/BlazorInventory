using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class WareHouseEntity
    {
        [Key]
        [StringLength(50)]
        public string WareHouseId { get; set; }

        [Required]
        [StringLength(150)]
        public string WareHouseName { get; set; }

        [Required]
        [StringLength(200)]
        public string WareHouseAddress { get; set; }

        //Relación con almacenamiento (StorageEntity)
        public ICollection<StorageEntity> Storages { get; set; }

    }
}
