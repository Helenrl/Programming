using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using InventoryItemNS;
using System.Collections.Generic;
 
namespace UnitTestInventoryItem
{
    [TestClass]
    public class UnitTestInventoryItem
    {

    
       [TestMethod]
        public void TestSetItem()
        {
            int counter = 2;
            InventoryItem item1 = new InventoryItem();
            InventoryItem item2 = new InventoryItem();
            List<InventoryItem> itemsList = new List<InventoryItem>();
            
            item1.SetItem("music table", 19.9, 1, DateTime.Parse("1/1/2014"));
            itemsList.Add(item1);
            item2.SetItem("toy", 30.99, 5, DateTime.Parse("1/1/2014"));
            itemsList.Add(item2);
            Assert.AreEqual(counter, itemsList.Count, "set items");
        }
       [TestMethod]
       public void TestOverrideEqualItemIsNullShouldBeFalse()
       {
           InventoryItem item = new InventoryItem();
           InventoryItem item1 = new InventoryItem();

           item.SetItem("music table", 19.9, 1, DateTime.Parse("1/1/2014"));

           item1 = null;
           Assert.AreEqual(false, item.Equals(item1), "obj is not null return true");

       }
       [TestMethod]
       public void TestOverrideEqualNotEqualShouldBeFalse()
       {
           InventoryItem item = new InventoryItem();
           string str="not equal";

           item.SetItem("music table", 19.9, 1, DateTime.Parse("1/1/2014"));
           Assert.AreEqual(false, item.Equals(str), "objs are equal return true");

       }

       [TestMethod]
       public void TestOverrideGetHashCode()
       {
           int expectedHashCode;
           int actual;
           InventoryItem item = new InventoryItem();
           item.SetItem("music table", 19.9, 1, DateTime.Parse("1/1/2014"));
           expectedHashCode = (Convert.ToInt32(item.itemPrice )) ^ item .location ;
           actual = item.GetHashCode();
           Assert.AreEqual(expectedHashCode, actual, "GetHashCode is not correct");
       }
       [TestMethod]
       public void TestgetshippedDateShouldBeToday()
       {
           
           InventoryItem item = new InventoryItem();
           item.SetItem("music table", 19.9, 1, DateTime.Parse("1/1/2014"));
           item.SetItemShippedDate(DateTime.Today);
           Assert.AreEqual(DateTime .Today , item .shippedDate, "GetHashCode is not correct");
       }
      }
    }


