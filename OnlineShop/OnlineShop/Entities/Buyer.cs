using OnlineShop.Entities;
using OnlineShop.Data;


namespace OnlineShop.Data.Entities
{
    public class Buyer : User
    {
        public int BuyerId { get; set; }

        public string BuyerEmail { get; set; }
        public Action<string>? ShowError { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public int DiscountCardId { get; set; }


        public Buyer()
        {

        }

        public Buyer(int Id, string email, ulong inn, string name, string surname, string phoneNumber, DateOnly userBirthDate, string address)
                                         : base(Id, inn, name, surname, phoneNumber, userBirthDate, address)
        {
            BuyerId = Id;

            BuyerEmail = email;
            //DiscountCardId = discountCardId;
        }

        public override string ToString()
        {
            return $"BuyerId: {this.BuyerId} {base.ToString()}  email: {this.BuyerEmail}";
        }


    }

}
