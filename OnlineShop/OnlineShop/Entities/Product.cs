using static System.Net.WebRequestMethods;

namespace OnlineShop.Entities
{
    public class Product
    {
        public int ProductID { get; init; }
        public string ProductName { get; set; } = string.Empty;
        public Manufacturer? ProductManufacturer { get; set; }
        public Supplier? ProductSupplier { get; set; }
        public double? ProductPrice { get; set; }

        public Product(int productID, string productName)
        {
            ProductID = productID;
            ProductName = productName;
        }

        public Product(int productID, string productName, double productPrice)
        {
            ProductID = productID;
            ProductName = productName;
            ProductPrice = productPrice;
        }

        public Product(int productID, string productName, Manufacturer productManufacturer, Supplier productSupplier, double productPrice)
        {
            ProductID = productID;
            ProductName = productName;
            ProductManufacturer = productManufacturer;
            ProductSupplier = productSupplier;  
            ProductPrice = productPrice;    
        }

        public Product()
        {

        }
        public override string ToString()
        {
            return $"ProductID: {ProductID}, ProductName: {ProductName}, ProductManufacturer: {ProductManufacturer}, ProductSupplier: {ProductSupplier}, ProductPrice: {ProductPrice}";
        }
    }
}

