namespace OnlineShop.Entities
{
    public class Manufacturer
    {
        public int ManufacturerID { get; init; }
        public string? ManufacturerName { get; set; } = "";
        public string? ManufacturerEDRPOU { get; set; } = "";

        public Manufacturer(int manufacturerID, string manufacturerName, string manufacturerEDRPOU)

        {
            ManufacturerID = manufacturerID;
            ManufacturerName = manufacturerName;
            ManufacturerEDRPOU = manufacturerEDRPOU;
        }

        // Конструктор за замовчуванням
        public Manufacturer()
        {
        }

        // Override the ToString method
        public override string ToString()
        {
            return $"ManufacturerID: {ManufacturerID}, ManufacturerName: {ManufacturerName}, ManufacturerEDRPOU: {ManufacturerEDRPOU}";
        }
    }
}