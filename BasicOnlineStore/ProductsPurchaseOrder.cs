using System;
using System.Collections.Generic;
using System.Text;

namespace BasicOnlineStore
{
    public class ProductsPurchaseOrder
    {
        public int AmountOrdered { get; set; }
        public ProductType Product { get; set; }
        public decimal Price { get; set; }

        public ProductsPurchaseOrder(ProductType productType, decimal price, int amountOrdered)
        {
            AmountOrdered = amountOrdered;
            Product = productType;
            Price = price;
        }
    }
}
