using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizontalScrollList.Models
{
    public class ItemModel
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string ItemDetail { get; set; }

        public ItemModel()
        {
            ID = 0;
            ItemName = string.Empty;
            ItemDetail = string.Empty;
        }
    }
}
