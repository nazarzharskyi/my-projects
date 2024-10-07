namespace OnlineShop.WebApi.DTOs
{
    public class CreateProductOnStockDto
    {
        public int ProductId {  get; set; }
        public int ProductAmount { get; set; }
        public int StockItemId { get; set; }
    }
}
