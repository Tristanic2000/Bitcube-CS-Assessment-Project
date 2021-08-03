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
        private IOnlineStore Store;//OnlineStore Store = new OnlineStore();
        private List<ProductType> productTypes;

        public HomeController(IOnlineStore _store)
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
            ProductsPurchaseOrder order = new ProductsPurchaseOrder();//P, 0, 0);
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
                    //try
                    //{
                    //    if (TempData["Store"] != null)
                    //        Store = (IOnlineStore)TempData["Store"];
                    //}
                    //catch
                    //{

                    //}
                    Store.AddProductsToInventory(purchaseOrder);

                    //TempData["Store"] = Store;
                    ViewData["Message"] = $"{purchaseOrder.AmountOrdered} {purchaseOrder.Product.ProductName}(s) successfully added to the inventory.";

                    return RedirectToAction("InventorySummary");
                }
                catch
                {
                  //  ModelState.AddModelError("error");
                }
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
            ProductsSellOrder order = new ProductsSellOrder();//P, 0);
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
                    //try
                    //{
                    //    if (TempData["Store"] != null)
                    //        Store = (IOnlineStore)TempData["Store"];
                    //}
                    //catch
                    //{

                    //}
                    ProductsSoldResult result = Store.SellProductsFromInventory(sellOrder);
                    string s = result.Result();

                    ViewData["Message"] = s;
                    //TempData["Store"] = Store;

                    if (result.Success)
                        return RedirectToAction("InventorySummary");


                    return View(sellOrder);
                }
                catch
                {

                }
            }
            return View(sellOrder);
        }


        public IActionResult InventoryItemSummary(string id)
        {
            ProductType P = productTypes.Where(p => p.ProductID == id).FirstOrDefault();

            //try
            //{
            //    if (TempData["Store"] != null)
            //        Store = (IOnlineStore)TempData["Store"];
            //}
            //catch
            //{

            //}

            InventoryItemSummary summary = Store.GetInventoryItemSummary(P);
            return View(summary);
        }

        public IActionResult InventorySummary()
        {
            //try
            //{
            //    if (TempData["Store"] != null)
            //        Store = (IOnlineStore)TempData["Store"];
            //}
            //catch
            //{

            //}

            InventorySummary summary = Store.GetInventorySummary();
            return View(summary);
        }
    }
}
