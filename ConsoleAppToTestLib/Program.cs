using System;
using BasicOnlineStore;
using BasicOnlineStore.Products;

namespace ConsoleAppToTestLib
{
    class Program
    {
        public static OnlineStore Store;
        static void Main()
        {
            Inventory inventory = new Inventory();
            Store = new OnlineStore(inventory);

            Menu();
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Please TYPE the number of which operation you would like to do:");
            Console.WriteLine("1. Add Products to Inventory");
            Console.WriteLine("2. Sell Products from Inventory");
            Console.WriteLine("3. Get Inventory Item Summary");
            Console.WriteLine("4. Get Inventory Overall Summary");
            Console.WriteLine("X. Exit Application");
            Console.Write("\nPress any key to continue...");

            char c = Console.ReadKey().KeyChar.ToString().ToUpper()[0];


            switch (c)
            {
                case '1':
                    AddProducts();
                    break;
                case '2':
                    SellProducts();
                    break;
                case '3':
                    InventoryItemSummary();
                    break;
                case '4':
                    InventorySummary();
                    break;
                case 'X':
                    Environment.Exit(0);
                    break;
                default:
                    Menu();
                    break;
            }
        }

        public static void AddProducts()
        {
            Console.Clear();
            Console.WriteLine("Please select which Product you would like to purchase:");
            Console.WriteLine("1. Laptop");
            Console.WriteLine("2. Phone");
            Console.WriteLine("3. Tablet");
            Console.WriteLine("X. Go Back to Main Menu.");
            Console.Write("\nPress any key to continue...");

            char c = Console.ReadKey().KeyChar.ToString().ToUpper()[0];

            ProductType productType = new ProductType("");
            decimal Price = 0;
            int Amount = 0;
            switch (c)
            {
                case '1':
                    productType = new Laptop();
                    break;
                case '2':
                    productType = new Phone();
                    break;
                case '3':
                    productType = new Tablet();
                    break;
                case 'X':
                    Menu();
                    break;
                default:
                    AddProducts();
                    break;
            }

            bool isValidPrice = false;
            while (isValidPrice == false)
            {
                Price = 0;
                Console.Clear();
                Console.WriteLine($"Please enter a Valid Price you are purchasing the {productType.ProductName} for:\nOr type X to return to the Add Products Menu");
                string s = Console.ReadLine();

                try
                {
                    if (s.ToUpper()[0] == 'X')
                        AddProducts();
                }
                catch { }


                isValidPrice = Decimal.TryParse(s, out Price);

                if (isValidPrice == false)
                {
                    Console.WriteLine($"{s} is not a valid decimal number price");
                    Console.Write("Press any key to try again, or press X to return to the Add Products Menu:");

                    char d = Console.ReadKey().KeyChar.ToString().ToUpper()[0];

                    if (d == 'X')
                        AddProducts();
                }
            }

            bool isValidAmount = false;
            while (isValidAmount == false)
            {
                Amount = 0;
                Console.Clear();
                Console.WriteLine($"Please enter a Positive Integer Amount for how many {productType.ProductName}s you want to purchase:\nOr type X to return to the Add Products Menu:");
                string s = Console.ReadLine();

                try
                {
                    if (s.ToUpper()[0] == 'X')
                        AddProducts();
                }
                catch { }


                isValidAmount = int.TryParse(s, out Amount);
                if (Amount <= 0)
                    isValidAmount = false;

                if (isValidAmount == false)
                {
                    Console.WriteLine($"{s} is not a Positive Integer Amount");
                    Console.Write("Press any key to try again, or X to return to the Add Products Menu");

                    try
                    {
                        char d = Console.ReadKey().KeyChar.ToString().ToUpper()[0];

                        if (d == 'X')
                            AddProducts();
                    }
                    catch { }

                }
            }

            Console.Clear();

            ProductsPurchaseOrder productsPurchaseOrder = new ProductsPurchaseOrder(productType, Price, Amount);
            Store.AddProductsToInventory(productsPurchaseOrder);

            Console.Write("\nPress any key to return to Main Menu...");
            Console.ReadKey();
            Menu();
        }

        public static void SellProducts()
        {
            Console.Clear();
            Console.WriteLine("Please select which Product you would like to sell:");
            Console.WriteLine("1. Laptop");
            Console.WriteLine("2. Phone");
            Console.WriteLine("3. Tablet");
            Console.WriteLine("X. Go Back to Main Menu.");
            Console.Write("\nPress any key to continue...");

            char c = Console.ReadKey().KeyChar.ToString().ToUpper()[0];

            ProductType productType = new ProductType("");
            int Amount = 0;
            switch (c)
            {
                case '1':
                    productType = new Laptop();
                    break;
                case '2':
                    productType = new Phone();
                    break;
                case '3':
                    productType = new Tablet();
                    break;
                case 'X':
                    Menu();
                    break;
                default:
                    SellProducts();
                    break;
            }


            bool isValidAmount = false;
            while (isValidAmount == false)
            {
                Amount = 0;
                Console.Clear();
                Console.WriteLine($"Please enter a Positive Integer Amount for how many {productType.ProductName}s you want to sell:\nOr type X to return to the Sell Products Menu:");
                string s = Console.ReadLine();

                try
                {
                    if (s.ToUpper()[0] == 'X')
                        AddProducts();
                }
                catch { }


                isValidAmount = int.TryParse(s, out Amount);
                if (Amount <= 0)
                    isValidAmount = false;

                if (isValidAmount == false)
                {
                    Console.WriteLine($"{s} is not a Positive Integer Amount");
                    Console.Write("\nPress any key to try again, or X to return to the Sell Products Menu");


                    try
                    {
                        char d = Console.ReadKey().KeyChar.ToString().ToUpper()[0];

                        if (d == 'X')
                            AddProducts();
                    }
                    catch { }
                }
            }

            ProductsSellOrder productsSellOrder = new ProductsSellOrder(productType, Amount);
            ProductsSoldResult result = Store.SellProductsFromInventory(productsSellOrder);

            Console.Clear();
            Console.WriteLine(result.Result());

            Console.Write("\nPress any key to return to Main Menu...");
            Console.ReadKey();
            Menu();
        }

        public static void InventoryItemSummary()
        {
            Console.Clear();
            Console.WriteLine("Please select which Product you would like to get a summary of:");
            Console.WriteLine("1. Laptop");
            Console.WriteLine("2. Phone");
            Console.WriteLine("3. Tablet");
            Console.WriteLine("X. Go Back to Main Menu.");
            Console.Write("\nPress any key to continue...");

            char c = Console.ReadKey().KeyChar.ToString().ToUpper()[0];

            ProductType productType = new ProductType("");
            switch (c)
            {
                case '1':
                    productType = new Laptop();
                    break;
                case '2':
                    productType = new Phone();
                    break;
                case '3':
                    productType = new Tablet();
                    break;
                case 'X':
                    Menu();
                    break;
                default:
                    InventoryItemSummary();
                    break;
            }

            InventoryItemSummary summary = Store.GetInventoryItemSummary(productType);

            Console.Clear();
            Console.WriteLine(summary.GetSummary());

            Console.Write("\nPress any key to return to Main Menu...");
            Console.ReadKey();
            Menu();
        }

        public static void InventorySummary()
        {
            InventorySummary summary = Store.GetInventorySummary();

            Console.Clear();
            Console.WriteLine(summary.GetSummary());

            Console.Write("\nPress any key to return to Main Menu...");
            Console.ReadKey();
            Menu();
        }
    }
}
