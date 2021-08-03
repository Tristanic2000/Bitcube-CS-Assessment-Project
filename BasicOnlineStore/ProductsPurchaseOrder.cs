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
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 0")]
        public int AmountOrdered { get; set; }

        public ProductType Product { get; set; }

        [Required(ErrorMessage = "Enter Price")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a value greater than 0")]
        public decimal Price { get; set; }

        public ProductsPurchaseOrder()//ProductType productType, decimal price, int amountOrdered)
        {
            AmountOrdered = 0;//amountOrdered;
            //Product = productType;
            Price = 0;//price;
        }
    }
}
