using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BasicOnlineStore
{
    public class ProductType
    {
        public string ProductName { get; set; }
        public string ProductID { get; set; } //not used
        //[Required(ErrorMessage = "Enter a price")]
        public decimal Price { get; set; }

        public ProductType(string _name)
        {
            ProductName = _name;
        }
    }
}