using OnlineShop.BusinessLayer.Services;
using OnlineShop.Constants;

namespace OnlineShop.BusinessLayer.Extensions
{
    public static class AddProductExtension
    {
        public static void CountChecker(this ProductsService products)
        {
            Console.WriteLine($"\n{NotificationConstants.LIST_AMOUNT} {products.GetProductsAmount()}\n");
        }
    }
}
