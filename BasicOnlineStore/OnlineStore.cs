using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BasicOnlineStore
{
    public class OnlineStore : IOnlineStore
    {
        private Inventory inventory { get; set; }

        public OnlineStore()
        {
            inventory = new Inventory();
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
            }
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