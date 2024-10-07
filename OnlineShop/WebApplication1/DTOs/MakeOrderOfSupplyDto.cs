namespace OnlineShop.WebApi.DTOs
{
    public class MakeOrderOfSupplyDto
    {
        public int SupplierID {  get; set; }
        public int ProductID { get; set; }
        public int ProductAmount {  get; set; }
        public DateTime OrderTime { get; set; }
    }
}
