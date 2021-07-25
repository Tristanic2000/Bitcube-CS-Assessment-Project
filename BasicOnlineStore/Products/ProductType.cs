using System;
using System.Collections.Generic;
using System.Text;

namespace BasicOnlineStore
{
    public class ProductType
    {
        public string ProductName { get; set; }
        public string ProdictID { get; set; }
        public decimal Price { get; set; }

        public ProductType(string _name)
        {
            ProductName = _name;
        }
    }
}