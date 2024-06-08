// See https://aka.ms/new-console-template for more information
using OnlineShop;

<<<<<<< HEAD
ManufacturerList manufacturersList = new ManufacturerList();
SupplierList suppliersList = new SupplierList();
ProductCategoryList productCategoryList = new ProductCategoryList();
ProductsList productsList = new ProductsList();
OrderFromSupplierList orderSupply = new OrderFromSupplierList();

manufacturersList.AddManufacturer(new Manufacturer(1, "Manufacturer1", "Manufacturer1"));
manufacturersList.AddManufacturer(new Manufacturer(2, "Manufacturer2", "Manufacturer2"));
Console.WriteLine(manufacturersList.ToString());

suppliersList.AddSupplier(new Supplier(1, "Supplier1", "Supplier1"));
suppliersList.AddSupplier(new Supplier(2, "Supplier2", "Supplier2"));
Console.WriteLine(suppliersList.ToString());

productCategoryList.AddProductCategory(new ProductCategory(1, "ProductCategory1"));
productCategoryList.AddProductCategory(new ProductCategory(2, "ProductCategory2"));
Console.WriteLine(productCategoryList.ToString());

productsList.AddProduct(new Product(1, "Product1"));
productsList.AddProduct(new Product(2, "Product2"));
Console.WriteLine(productsList.ToString());


string time = GetTime();
int orderId = 1;
orderSupply.OrderSupply(new OrderFromSupplier(orderId, 1, 1, 5, time, 1));
orderId++;
orderSupply.OrderSupply(new OrderFromSupplier(orderId, 1, 2, 5, time, 1));
orderId++;
Console.WriteLine(orderSupply.ToString());
string GetTime()
{
    string timeNow = DateTime.Now.ToString();
    return timeNow;
}
=======
internal class Program
{
    private static void Main(string[] args)
    {
        ProductsCatalogFlow mainFlow = new ProductsCatalogFlow();
        mainFlow.CatalogProcesses();
    }
}
>>>>>>> 47048515ae6f17c7013aef12d60611171863d76a
