using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Business;
using BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WebProjectTest {
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestPurchaseManager {
        public TestPurchaseManager() {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;
        private Mock<ITransactionManager> transct;
        private Mock<IBillingGateway> billing;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //

         //Use TestInitialize to run code before running each test 
         [TestInitialize()]
         public void MyTestInitialize() {
             transct = new Mock<ITransactionManager>();
             billing = new Mock<IBillingGateway>();
         }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestExecuteOrder()
        {
            billing.Setup(p => p.GetProviderInfo(It.IsAny<string>())).Returns("providerstring");
            var success = false;
            var orderMock = new Mock<OrderDetails>();
            orderMock.Setup(o => o.OrderId).Returns(1234);
            PurchaseManager pm = new PurchaseManager(transct.Object, billing.Object);
            try {
                pm.ExecuteOrder(orderMock.Object);
                success = true;
            }
            catch (Exception) {
                success = false;
                throw;
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestExecuteOrder_Fails() {
            var success = false;
            var order = new OrderDetails(); PurchaseManager pm = new PurchaseManager(transct.Object, billing.Object);
            try {

                pm.ExecuteOrder(order);
                success = true;
            }
            catch (Exception) {
                success = false;
                throw;
            }
            Assert.IsTrue(success);


        }
    }
}
