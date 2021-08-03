//using BasicStoreFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BasicOnlineStore;
using BasicOnlineStore.Products;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BasicStoreFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private IOnlineStore Store;
        private List<ProductType> productTypes;

        public HomeController(IOnlineStore _store)  //Added as a Singleton service so that the data inside store.inventory will persist between postbacks
        {
            Store = _store;
                
            productTypes = new List<ProductType>();
            productTypes.Add(new Laptop());
            productTypes.Add(new Phone());
            productTypes.Add(new Tablet());
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "";
            return View(productTypes);
        }


        public IActionResult Add(string id)
        {
            ProductType P = productTypes.Where(p => p.ProductID == id).FirstOrDefault();
            ProductsPurchaseOrder order = new ProductsPurchaseOrder();
            order.Product = P;

            return View(order);
        }


        [HttpPost]
        public IActionResult Add(ProductsPurchaseOrder purchaseOrder, string id)
        {
            ProductType P = productTypes.Where(p => p.ProductID == id).FirstOrDefault();
            purchaseOrder.Product = P;

            if (ModelState.IsValid)
            {
                try
                {
                    Store.AddProductsToInventory(purchaseOrder);

                    ViewData["Message"] = $"{purchaseOrder.AmountOrdered} {purchaseOrder.Product.ProductName}(s) successfully added to the inventory.";

                    return RedirectToAction("InventorySummary");
                }
                catch {  }
            }
            if (purchaseOrder == null)
            {
                ViewData["Message"] = "Purchase Order is null.";
            }
            return View(purchaseOrder);
        }



        public IActionResult Sell(string id)
        {
            ProductType P = productTypes.Where(p => p.ProductID == id).FirstOrDefault();
            ProductsSellOrder order = new ProductsSellOrder();
            order.Product = P;

            return View(order);
        }

        [HttpPost]
        public IActionResult Sell(ProductsSellOrder sellOrder, string id)
        {
            ProductType P = productTypes.Where(p => p.ProductID == id).FirstOrDefault();
            sellOrder.Product = P;

            if (ModelState.IsValid)
            {
                try
                {
                    ProductsSoldResult result = Store.SellProductsFromInventory(sellOrder);
                    string s = result.Result();

                    ViewData["Message"] = s;

                    if (result.Success)
                        return RedirectToAction("InventorySummary");


                    return View(sellOrder);
                }
                catch {  }
            }
            return View(sellOrder);
        }


        public IActionResult InventoryItemSummary(string id)
        {
            ProductType P = productTypes.Where(p => p.ProductID == id).FirstOrDefault();

            InventoryItemSummary summary = Store.GetInventoryItemSummary(P);
            return View(summary);
        }

        public IActionResult InventorySummary()
        {
            InventorySummary summary = Store.GetInventorySummary();
            return View(summary);
        }
    }
}
