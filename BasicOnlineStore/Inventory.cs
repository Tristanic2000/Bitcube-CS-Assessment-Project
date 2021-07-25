using System;
using System.Collections.Generic;
using System.Text;

namespace BasicOnlineStore
{
    public class Inventory
    {
        public List<ProductType> Items{ get; set; }

        public Inventory()
        {
            Items = new List<ProductType>();
        }
    }
}
