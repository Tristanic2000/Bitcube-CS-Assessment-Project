using System;
using System.Collections.Generic;
using System.Text;

namespace BasicOnlineStore
{
    public class ProductsSellOrder
    {
        public ProductType Product { get; set; }
        public int AmountSelling { get; set; }

        public ProductsSellOrder(ProductType product, int amountSelling)
        {
            Product = product;
            AmountSelling = amountSelling;
        }
    }
}
