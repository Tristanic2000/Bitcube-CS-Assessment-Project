using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BasicOnlineStore
{
    public class InventoryItemSummary
    {
        public List<ProductType> Products { get; set; }

        public InventoryItemSummary(IEnumerable<ProductType> productTypes)
        {
            Products = productTypes.ToList();
        }

        public string GetSummary()
        {
            decimal AveragePrice = 0;
            string temp = "";

            if (Products.Count > 0)
            {
                int Count = Products.Count;
                string name = Products[0].ProductName;

                temp += $"Item Summary for: {name} \n";
                temp += "======================================\n";
                temp += $"Total Items: {Count} \n";

                for (int i = 0; i < Count; i++)
                    AveragePrice += Products[i].Price;
                
                AveragePrice = AveragePrice / Count;

                temp += $"Average Price: {AveragePrice.ToString("C2")}";
            }
            else
                temp = "There is currently no such item in storage";

            return temp;
        }
    }
}
