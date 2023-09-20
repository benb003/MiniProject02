using System;
using System.Text;

namespace MiniProject02
{
	public class Product
	{
        public Product(string category, string productName, int price)
        {
            Category = category;
            ProductName = productName;
            Price = price;
        }

        public string Category { get; set; }
        public string ProductName { get; set; }
		public int Price { get; set; }

        public override string ToString()
        {
            return $"{Category.PadRight(30)}{ProductName.PadRight(30)} {Price}";
        }
	}
}

