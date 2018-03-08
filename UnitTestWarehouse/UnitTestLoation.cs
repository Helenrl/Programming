using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventoryItemNS;
using System.Collections.Generic;
using Warehouse_lly;
using System.IO ;

namespace UnitTestWarehouse
{
    [TestClass]
    public class TestLocation
    {
        static class Constants
        {
            public const int LocationNumbers = 10;
        }
        [TestMethod]
        public void TestAddNewItem()
        {
            int counter = 6;
            Location loc = new Location();
            InventoryItem item1 = new InventoryItem();
            InventoryItem item2 = new InventoryItem();
            InventoryItem item3 = new InventoryItem();
            InventoryItem item4 = new InventoryItem();
            InventoryItem item5 = new InventoryItem();
            InventoryItem newItem = new InventoryItem();
            item1.SetItem("music table", 19.9, 1, DateTime.Parse("1/1/2014"));
            item2.SetItem("table", 220.0, 2, DateTime.Parse("12/31/2014"));
            item3.SetItem("wipe", 22.0, 3, DateTime.Parse("12/31/2013"));
            item4.SetItem("diaper", 30.99, 4, DateTime.Parse("12/31/2013"));
            item5.SetItem("playmat", 30.99, 5, DateTime.Parse("12/31/2013"));
            loc.itemsList.Add(item1);
            loc.itemsList.Add(item2); 
            loc.itemsList.Add(item3);
            loc.itemsList.Add(item4);
            loc.itemsList.Add(item5);
            newItem.SetItem("bell", 30.99, 5, DateTime.Parse("1/1/2014"));
            loc.AddItemIn(newItem);
            Assert.AreEqual(counter, loc.itemsList.Count, "new item is added in the location");
        }
        [TestMethod]
        public void TestAddSameNameItem()
        {
            int counter = 6;
            Location loc = new Location();
            InventoryItem item1 = new InventoryItem();
            InventoryItem item2 = new InventoryItem();
            InventoryItem item3 = new InventoryItem();
            InventoryItem item4 = new InventoryItem();
            InventoryItem item5 = new InventoryItem();
            InventoryItem newItem = new InventoryItem();
            item1.SetItem("music table", 19.9, 1, DateTime.Parse("1/1/2014"));
            item2.SetItem("table", 220.0, 2, DateTime.Parse("12/31/2014"));
            item3.SetItem("wipe", 22.0, 3, DateTime.Parse("12/31/2013"));
            item4.SetItem("diaper", 30.99, 4, DateTime.Parse("12/31/2013"));
            item5.SetItem("playmat", 30.99, 5, DateTime.Parse("12/31/2013"));
      
            loc. itemsList.Add(item1);
            loc. itemsList.Add(item2);
            loc.itemsList.Add(item3);
            loc.itemsList.Add(item4);
            loc.itemsList.Add(item5);
         
            newItem.SetItem("music table", 30.99, 5, DateTime.Parse("1/1/2014"));
            loc.AddItemIn(newItem);
            Assert.AreEqual(counter, loc.itemsList.Count, "new item is added in the location");
        }
        [TestMethod]
        public void TestAddNewItemWithDifferenctExpirationDate()
        {
            int counter = 5;
            Location loc = new Location();
            InventoryItem item1 = new InventoryItem();
            InventoryItem item2 = new InventoryItem();
            InventoryItem item3 = new InventoryItem();
            InventoryItem item4 = new InventoryItem();
            InventoryItem item5 = new InventoryItem();
            InventoryItem newItem = new InventoryItem();
            item1.SetItem("music table", 19.9, 1, DateTime.Parse("1/1/2014"));
            item2.SetItem("table", 220.0, 2, DateTime.Parse("12/31/2014"));
            item3.SetItem("wipe", 22.0, 3, DateTime.Parse("12/31/2013"));
            item4.SetItem("diaper", 30.99, 4, DateTime.Parse("12/31/2013"));
            item5.SetItem("playmat", 30.99, 5, DateTime.Parse("12/31/2013"));
            List<InventoryItem> itemsList = new List<InventoryItem>();
            loc.itemsList.Add(item1);
            loc.itemsList.Add(item2);
            loc.itemsList.Add(item3);
            loc.itemsList.Add(item4);
            loc.itemsList.Add(item5);
            newItem.SetItem("music table", 30.99, 5, DateTime.Parse("1/1/2013"));
            loc.AddItemIn(newItem);
            Assert.AreEqual(counter, loc.itemsList.Count, "new item cound not be added in the location");
        }
       
       
    }
}
