using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;

namespace Business {
    public class PurchaseManager
    {
        private ITransactionManager transactionManager;
        private IBillingGateway billingGateway;

        public PurchaseManager(ITransactionManager transaction, IBillingGateway billing)
        {
            transactionManager = transaction;
            billingGateway = billing;
        }

        public  void ExecuteOrder(OrderDetails order )
        {
            //check for the order details, collect user info
            string provider = billingGateway.GetProviderInfo("");

            var transctId =transactionManager.InitializeTransaction(order.OrderId, provider);

            billingGateway.MakePayment(100, "", "", "");

            transactionManager.FinalizeTransaction(transctId);
        }
    }
}
