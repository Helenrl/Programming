using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventoryItemNS;
using System.Collections.Generic;
using Warehouse_lly;
using System.IO ;
using TestHarnessNS;

namespace UnitTestWarehouse
{
    [TestClass]
    public class TestWarehouse
    {
        static class Constants
        {
            public const int LocationNumbers = 10;
            public const int WarehouseNumber = 2;
  
        }
        [TestMethod]
        public void TestAddNewIteminLocation()
        {
            int counter = 2;
            int actualCounter;
            InventoryItem newItem = new InventoryItem();
            Warehouse w = new Warehouse();
            newItem.SetItem("bell", 30.99, 5, DateTime.Parse("1/1/2014"));
            w = InitialWarehouse("Items.txt");
           actualCounter=w.AddItemsInLocation(newItem);
           Assert.AreEqual(counter, actualCounter, "new item is added in the location");
        }

        [TestMethod]
        public void TestRemoveItemFromLocation()
        {
            int counter = 0;
            int actualCounter;
            InventoryItem item = new InventoryItem();
            Warehouse w = new Warehouse();
            item.SetItem("mobile", 30.99, 5, DateTime.Parse("12/31/2013"));
            w = InitialWarehouse("Items.txt");
            actualCounter = w.RemoveItemsFromLocation(item);
            Assert.AreEqual(counter, actualCounter, "new item is removed in the location");
        }
      
       
        [TestMethod]
        public void TestWarehouswithExpiratedItems()
        {
            Warehouse w1 = new Warehouse();
            Warehouse w2 = new Warehouse();
            List<InventoryItem> itemsList = new List<InventoryItem>();
            for (int i = 0; i < Constants.LocationNumbers; i++)
            {
                w1.location[i] = new Location();
            }
            for (int i = 0; i < Constants.LocationNumbers; i++)
            {
                w2.location[i] = new Location();
            }
            w1=InitialWarehouse("Warehouseitems1.txt");
            w2= InitialWarehouse("Warehouseitems2.txt");
            w1.totalExpiratedItems = w1.CounteNumberofExpiratedItems();
            w2.totalExpiratedItems = w2.CounteNumberofExpiratedItems();
            Assert.IsTrue(w1.totalExpiratedItems > w2.totalExpiratedItems);
        }

        [TestMethod]
        public Warehouse InitialWarehouse(string fileName)
        {
           
            Warehouse w = new Warehouse();
            List<InventoryItem> itemsList = new List<InventoryItem>();
            List<string> lineList = new List<string>();
            int locationID = 0;
            FileOperation readFile = new FileOperation();
            char[] delimiterChars = { ',', ';', '#' };
            string[] var = new string[4];       
            for (int i = 0; i < Constants.LocationNumbers; i++)
            {
               w.location[i] = new Location();
            }
            lineList = readFile.ReadFile(fileName);
            foreach (string l in lineList)
            {
                var = l.Split(delimiterChars);
                InventoryItem items = new InventoryItem();
                items.SetItem(var[0], Convert.ToDouble(var[1]), Convert.ToInt32(var[2]), DateTime.Parse(var[3]));
                locationID = Convert.ToInt32(var[2]);
                w.location[locationID].itemsList.Add(items);  
            }
           return w;
         }

     
    }
}
