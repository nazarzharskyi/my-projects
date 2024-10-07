using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
    internal class Review
    {
        public int PaymentType_Id;
        public PaymnetTypes paymnetType;

        public Review()
        {

        }

        public Review(PaymnetTypes type)
        {
            PaymentType_Id = (int)type;

            paymnetType = type;
        }


    }

    enum PaymnetTypes
    {
        cash_on_delivery,
        on_bank_account,
        by_card_transfer
    }
}
