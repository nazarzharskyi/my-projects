using OnlineShop.Data.Entities;
using OnlineShop.Entities;
namespace OnlineShop.Entities
{
    public record DiscountCard
    {
        public int DiscountCard_ID { get; init; }
        public double PercanatageDiscount { get; set; }
        public Buyer buyer { get; set; }
        public DiscountCard()
        {

        }
        public DiscountCard(Buyer _buyer, double percanatageDiscount)
        {
            buyer = _buyer;
            PercanatageDiscount = percanatageDiscount;
        }
        public DiscountCard(int discountCard_ID, Buyer _buyer, double percanatageDiscount)
        {
            DiscountCard_ID = discountCard_ID;
            buyer = _buyer;
            PercanatageDiscount = percanatageDiscount;
        }
        public override string ToString()
        {
            return $"Discount card ID: {DiscountCard_ID}, Buyer: {buyer}, Percantage Discount: {PercanatageDiscount}";
        }
    }
}