using OnlineShop.Entities;

public static class ProductStocksExtensions
{
    public static bool IsInStock(this ProductStocks productStock)
    {
        return productStock.ProductAmount > 0;
    }

    public static string GetStockSummary(this ProductStocks productStock)
    {
        if (!IsInStock(productStock))
        {
            return "Product is not available on the stock.";
        }
        // It showes Unknown product if this product wasn`t found in database
        return $"{productStock.product?.ProductName ?? "Unknown Product"} has {productStock.ProductAmount} units in stock.";
    }
}