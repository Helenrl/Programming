using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warehouse_lly;
using InventoryItemNS;
using TestHarnessNS;


namespace UnitTestWarehouse
{
    [TestClass]
    public class UnitTestTestharness
    {
        public UnitTestTestharness()
        {
        }
        static class Constants
        {
            public const int LocationNumbers = 10;
            public const int WarehouseNumber = 2;

        }
        [TestMethod]
        public void TestWarehouswithMostItems()
        {
            Testharness t = new Testharness();
            Warehouse[] w = new Warehouse[Constants.WarehouseNumber];
         

            for (int i = 0; i < Constants.WarehouseNumber; i++)
            {
                w[i] = new Warehouse();
            }
      
            w[0] = Testharness .InitialWarehouse("Warehouseitems1.txt", "warehouse1");
            w[1] = Testharness.InitialWarehouse("Warehouseitems2.txt", "warehouse2");
            w[0].totalItems =w[0].CounteTotalItems();
            w[1].totalItems=w[1].CounteTotalItems();
            t.WarehouswithMostItems(w);
            Assert.IsTrue(w[0].totalItems > w[1].totalItems);
        }
        [TestMethod]
        public void TestWarehouswithMostItemsShouldBeEqual()
        {
            Testharness t = new Testharness();
            Warehouse[] w = new Warehouse[Constants.WarehouseNumber];
            for (int i = 0; i < Constants.WarehouseNumber; i++)
            {
                w[i] = new Warehouse();
            }
            w[0] = Testharness.InitialWarehouse("Warehouseitems1.txt", "warehouse1");
            w[1] = Testharness.InitialWarehouse("Warehouseitems1.txt", "warehouse2");
            w[0].CounteTotalItems();
            w[1].CounteTotalItems();
            t.WarehouswithMostItems(w);
            Assert.IsTrue(w[0].totalItems >= w[1].totalItems);
        }

        [TestMethod]
        public void TestWarehouswithMostItemsShouldBeLess()
        {
            Testharness t = new Testharness();
            Warehouse[] w = new Warehouse[Constants.WarehouseNumber];
          
            for (int i = 0; i < Constants.WarehouseNumber; i++)
            {
                w[i] = new Warehouse();
            }
  
            w[0] = Testharness.InitialWarehouse("Warehouseitems2.txt", "warehouse1");
            w[1] = Testharness.InitialWarehouse("Warehouseitems1.txt", "warehouse2");
            w[0].CounteTotalItems();
            w[1].CounteTotalItems();
            t.WarehouswithMostItems(w);
            Assert.IsTrue(w[0].totalItems < w[1].totalItems);
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
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestharnessNumberOfExpiratedItemInWarehouse()
        {
            Warehouse[] w = new Warehouse[2];
            double expectedW1ItemsNumberofExpiration =3;
            double expectedW2ItemsNumberofExpiration =1;
            double ActualW1ItemsNumberofExpiration;
            double ActualW2ItemsNumberofExpiration;

            for (int j = 0; j < Constants.WarehouseNumber; j++)
            {
                w[j] = new Warehouse();
            }
            w=Testharness.WarehouswithExpiratedItems();
            ActualW1ItemsNumberofExpiration = w[0].totalExpiratedItems;
            ActualW2ItemsNumberofExpiration = w[1].totalExpiratedItems;
            Assert.AreEqual( expectedW1ItemsNumberofExpiration, ActualW1ItemsNumberofExpiration);
            Assert.AreEqual(expectedW2ItemsNumberofExpiration, ActualW2ItemsNumberofExpiration);
        }
        [TestMethod]
        public void TestharnessRejectIn()
        {
            int expectedCounter=1;
            int actualCounter;        
            actualCounter  = Testharness.RejectItemIn();
            Assert.AreEqual(expectedCounter, actualCounter);
        }
       
    }
}
