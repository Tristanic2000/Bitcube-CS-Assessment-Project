using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BasicOnlineStore
{
    public class OnlineStore : IOnlineStore
    {
        private Inventory inventory { get; set; }

        public OnlineStore()//Inventory _inv)
        {
            inventory = new Inventory();//_inv;
        }


        public void AddProductsToInventory(ProductsPurchaseOrder purchaseOrder)
        {
            if (purchaseOrder != null)
            {
                for (int i = 0; i < purchaseOrder.AmountOrdered; i++)
                {
                    purchaseOrder.Product.Price = purchaseOrder.Price;
                    inventory.Items.Add(purchaseOrder.Product);
                }
               // Console.WriteLine("Product(s) Successfully added.");
            }
          //  else
               // Console.WriteLine("ProductsPurchaseOrder is null.");
        }

        public InventoryItemSummary GetInventoryItemSummary(ProductType stockType)
        {
            IEnumerable<ProductType> list = inventory.Items.Where(p => p.ProductName == stockType.ProductName);
            InventoryItemSummary temp = new InventoryItemSummary(list);

            return temp;
        }

        public InventorySummary GetInventorySummary()
        {
            return new InventorySummary(inventory);
        }

        public ProductsSoldResult SellProductsFromInventory(ProductsSellOrder itemsSoldOrder)
        {
            return new ProductsSoldResult(itemsSoldOrder.Product, itemsSoldOrder.AmountSelling, inventory);
        }
    }
}