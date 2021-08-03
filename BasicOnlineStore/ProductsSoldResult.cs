using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicOnlineStore
{
    public class ProductsSoldResult 
    { 
        private ProductType ProductType { get; set; }
        private int AmountSold { get; set; }
        private Inventory inventory { get; set; }

        public bool Success { get; set; }

        public ProductsSoldResult(ProductType productType, int amountSold, Inventory inv)
        {
            ProductType = productType;
            AmountSold = amountSold;
            inventory = inv;
            Success = false;
        }

        public string Result()
        {
            IEnumerable<ProductType> temp = inventory.Items.Where(p => p.ProductName == ProductType.ProductName);
            List<ProductType> list = temp.ToList();

            string s = "";

            if (list != null && list.Count >= AmountSold)
            {
                decimal Total = 0;
                int iCount = 0;
                int i = 0;
                do
                {
                    if (inventory.Items[i].ProductName == ProductType.ProductName)
                    {
                        Total += inventory.Items[i].Price;
                        inventory.Items.RemoveAt(i);
                        i++;
                        iCount++;
                    }
                    else
                        i++;
                }
                while (iCount != AmountSold);

                s += $"{AmountSold} {ProductType.ProductName}(s) sold for: {Total.ToString("C2")}";
                Success = true;
            }
            else
            {
                Success = false;
                s += $"Unable to sell {AmountSold} {ProductType.ProductName}s due to insufficient stock.";
            }

            return s;
        }
    }
}
