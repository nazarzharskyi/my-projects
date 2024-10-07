namespace OnlineShop.WebApi.DTOs
{
    public class UpdateOfAmountOnStockDto
    {
        public int ProductID { get; set; }
        public int ProductAmount { get; set; }
        public int StockItemID { get; set; }
    }
}
