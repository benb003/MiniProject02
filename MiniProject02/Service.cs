using System;
namespace MiniProject02
{
    public class Service
    {
        private static List<Product> products = new List<Product>();
        private static int totalPrice = 0;

        public void PrintWelcome()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*************************************************");
            Console.WriteLine("***   WELCOME TO THE PRODUCT APPLICATION      ***");
            Console.WriteLine("*************************************************");
            Console.ResetColor();
        }

        public void ShowMainMenu()
        {

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-> Select an action     <-");
            Console.ResetColor();
            Console.WriteLine("1: Add a product");
            Console.WriteLine("2: Search a product");
            Console.WriteLine("3: List products");
            Console.WriteLine("0: Quit");

            Console.Write("Your selection: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    SearchProduct();
                    break;
                case "3":
                    ListProduct();
                    break;
                case "0":
                    Console.WriteLine("Thank you for using our application.");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    ShowMainMenu();
                    break;
            }
        }

        public void AddProduct()
        {
            Console.Write("Enter a category: ");
            string category = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter a product name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter a price: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int price);
            if (!isValid)
            {
                Console.WriteLine("invalid price. try again.");
                ShowMainMenu();
            }
            products.Add(new Product(category, name, price));
            totalPrice += price;
            Console.WriteLine("The product was added");
            ShowMainMenu();
            
        }

        public void SearchProduct()
        {
            Console.Write("Enter a product name: ");
            string searchedProduct = Console.ReadLine() ?? string.Empty;
            foreach (var product in products)
            {
                if (searchedProduct == product.ProductName)
                {
                    Console.WriteLine("Product was found. Details:");
                    Console.WriteLine("------------------------------------------------------------------");

                    Console.WriteLine("CATEGORY".PadRight(30) + "PRODUCT NAME".PadRight(30) + "PRICE");
                    Console.WriteLine(product);
                    Console.WriteLine("------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Product was not found.");
                }
                ShowMainMenu();
            }
        }

        public void ListProduct()
        {
            List<Product> sortedProducts = products.OrderBy(p => p.Price).ToList();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("CATEGORY".PadRight(30)+"PRODUCT NAME".PadRight(30)+"PRICE");
            foreach (var product in sortedProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("Total Price: ".PadLeft(61)+ totalPrice);
            Console.WriteLine("------------------------------------------------------------------");
            ShowMainMenu();
        }
    }
}

