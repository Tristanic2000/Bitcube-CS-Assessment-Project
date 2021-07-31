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

namespace BasicStoreFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private OnlineStore Store;
        private Inventory Inventory;

        public HomeController(OnlineStore store)
        {
            Store = store;
            //Inventory = store
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
