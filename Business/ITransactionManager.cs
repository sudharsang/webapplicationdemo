using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business {
    public interface ITransactionManager
    {
        UInt64 InitializeTransaction(int orderId, string provider);

        void FinalizeTransaction(UInt64 trasctId);
    }

}
