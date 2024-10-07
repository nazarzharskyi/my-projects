namespace OnlineShop.Entities
{
    public class ProductStocks
    {
        public Product? product { get; set; }
        public int ProductAmount { get; set; }
        public int StockItemID { get; set; }
        public ProductStocks()
        {

        }
        public ProductStocks(int productAmount)
        {
            ProductAmount = productAmount;
        }
        public ProductStocks(Product _product, int productAmount)
        {
            product = _product;
            ProductAmount = productAmount;
        }
        public ProductStocks(Product _product, int productAmount, int stockItemID)
        {
            product = _product;
            ProductAmount = productAmount;
            StockItemID = stockItemID;
        }
        public override string ToString()
        {
            return $"Product: {product}, Product Amount: {ProductAmount}, Stock Item ID: {StockItemID}";
        }
    }
}