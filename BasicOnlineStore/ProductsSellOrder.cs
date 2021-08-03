using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BasicOnlineStore
{
    public class ProductsSellOrder
    {
        public ProductType Product { get; set; }

        [Required(ErrorMessage = "Enter Amount")]
        [DisplayName("Amount Selling")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 0")]
        public int AmountSelling { get; set; }

        public ProductsSellOrder()//ProductType product, int amountSelling)
        {
            // Product = product;
            AmountSelling = 0;
        }
    }
}
