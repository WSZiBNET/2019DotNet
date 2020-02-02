using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaBel.Models
{
    public class ItemViewModel
    {
        public List<ItemModel> Items{ get; set; }
        public List<ItemTypeModel> ItemType { get; set; }
        public List<ItemCategoryModel> ItemCategory { get; set; }


    }
}
