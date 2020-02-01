using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaBel.Models
{
    [Table("Items")]
    public class ItemModel
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ItemType")]
        public int TypeName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("ItemCategory")]
        public int Category { get; set; }
    }

    [Table("ItemType")]
    public class ItemTypeModel
    {
        [Key]
        public int ID { get; set; }
        public string TypeName { get; set; }
    }

    [Table("ItemCategory")]
    public class ItemCategoryModel
    {
        [Key]
        public int ID { get; set; }
        public string CategoryName { get; set; }
    }
}
