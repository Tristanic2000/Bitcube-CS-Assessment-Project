using System;
using System.Collections.Generic;
using System.Text;

namespace BasicOnlineStore
{
    public interface IOnlineStore
    {
        void AddProductsToInventory(ProductsPurchaseOrder purchaseOrder);
        ProductsSoldResult SellProductsFromInventory(ProductsSellOrder itemsSoldORder);
        InventoryItemSummary GetInventoryItemSummary(ProductType stockType);
        InventorySummary GetInventorySummary();
    }
}
