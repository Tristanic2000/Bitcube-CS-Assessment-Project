using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicOnlineStore.Products;

namespace BasicOnlineStore
{
    public class InventorySummary
    {
        private Inventory inv { get; set; }

        public InventorySummary(Inventory inventory)
        {
            inv = inventory;
        }

        public string GetSummary()
        {
            string temp = "Inventory Summary\n";

            IEnumerable<ProductType> laptop = inv.Items.Where(p => p.ProductName == "Laptop");
            IEnumerable<ProductType> phone = inv.Items.Where(p => p.ProductName == "Phone");
            IEnumerable<ProductType> tablet = inv.Items.Where(p => p.ProductName == "Tablet");

            temp += "===============================\n";

            temp += ProductSummary(laptop);
            temp += ProductSummary(phone);
            temp += ProductSummary(tablet);

            return temp;
        }

        private string ProductSummary(IEnumerable<ProductType> _PT)
        {
            string s = "";
            List<ProductType> PT = _PT.ToList();

            if (PT != null && PT.Count > 0)
            {
                s += $"\nItem: {PT[0].ProductName}\n";
                s += "================================\n";
                s += $"Total {PT[0].ProductName}s: {PT.Count}\n";

                decimal avg = 0;
                for (int i = 0; i < PT.Count; i++)
                {
                    avg += PT[i].Price;
                }
                avg = avg / PT.Count;

                s += $"Average Price: {avg.ToString("C2")}\n";
                s += "================================\n";
            }

            return s;
        }
    }
}
