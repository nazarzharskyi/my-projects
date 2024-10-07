namespace OnlineShop.Entities
{
    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        public string? ManufacturerName { get; set; } = "";
        public string? ManufacturerEDRPOU { get; set; } = "";
        public string CreatedDate1 { get; set; }

        public List<Product>? Products { get; set; }

        public Manufacturer(int мanufacturerId, string manufacturerName, string manufacturerEDRPOU)
        {
            ManufacturerID = мanufacturerId;
            ManufacturerName = manufacturerName;
            ManufacturerEDRPOU = manufacturerEDRPOU;
        }

        // Конструктор за замовчуванням
        public Manufacturer()
        {
            Products = new List<Product>();
        }

        // Override the ToString method
        public override string ToString()
        {
            return $"МanufacturerID: {ManufacturerID}, ManufacturerName: {ManufacturerName}, ManufacturerEDRPOU: {ManufacturerEDRPOU}";
        }
    }
}