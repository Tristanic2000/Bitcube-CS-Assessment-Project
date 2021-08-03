using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BasicOnlineStore
{
    public class ProductsPurchaseOrder
    {
        [Required(ErrorMessage ="Enter Amount")]
        [DisplayName("Amount Ordering")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be at least 1")]
        public int AmountOrdered { get; set; }

        public ProductType Product { get; set; }

        [Required(ErrorMessage = "Enter Price")]
        [Range(1, double.MaxValue, ErrorMessage = "Value must be at least 1,00")]
        public decimal Price { get; set; }

        public ProductsPurchaseOrder()//ProductType productType, decimal price, int amountOrdered)
        {
            //Product = productType;
            AmountOrdered = 0;
            Price = 0;
        }
    }
}
