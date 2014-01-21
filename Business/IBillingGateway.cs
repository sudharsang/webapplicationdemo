using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business {
    public interface IBillingGateway
    {
         UInt64 MakePayment(int amount, string cardUser, string cardNumber, string cvvNumber);

        string GetProviderInfo(string cardNumber);
    }
}
