using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryItemNS;
using Warehouse_lly;
using System.IO;

namespace TestHarnessNS
{
    public class Testharness
    {
        static  class Constants
        {
           public const int LocationNumbers = 10;
           public const int WarehouseNumber = 2;

        }
        public static Warehouse InitialWarehouse(string fileName, string warehouseName)
        {

            Warehouse w = new Warehouse();
            List<InventoryItem> itemsList = new List<InventoryItem>();
            List<string> lineList = new List<string>();
            int locationID = 0;

            FileOperation readFile = new FileOperation();
            char[] delimiterChars = { ',', ';', '#' };
            string[] var = new string[4];
            w.wName = warehouseName;
            for (int i = 0; i < Constants.LocationNumbers; i++)
            {
                w.location[i] = new Location();
            }
            lineList = readFile.ReadFile(fileName);
            foreach (string l in lineList)
            {
                var = l.Split(delimiterChars);
                InventoryItem items = new InventoryItem();
                items.SetItem(var[0], Convert.ToDouble(var[1]), Convert.ToInt32(var[2]), (DateTime.Parse(var[3])).Date );
                locationID = Convert.ToInt32(var[2]);
                w.location[locationID].itemsList.Add(items);
            }
            return w;
        }
        public string WarehouswithMostItems(Warehouse[] w)
        {
            double max = w[0].totalItems;
            string name=w[0].wName ;
            for (int i = 0; i < Constants.WarehouseNumber; i++)
              if (w[i].totalItems > max)
                {
                    max = w[i].totalItems;
                    name = w[i].wName;                  
                }
            Console.Out.WriteLine("Most items are in {0}", max);
            return name;
            
        }

        public static Warehouse[] WarehouswithExpiratedItems()
        {
            Warehouse[] w = new Warehouse[Constants.WarehouseNumber];
            List<InventoryItem> itemsList = new List<InventoryItem>();

            for (int j = 0; j < Constants.WarehouseNumber; j++)
            {
                w[j] = new Warehouse();
            }

            for (int j = 0; j < Constants.LocationNumbers; j++)
            {
                w[0].location[j] = new Location();
                w[1].location[j] = new Location();
            }

            w[0] = InitialWarehouse("Warehouseitems1.txt", "warehouse1");
            w[0].totalExpiratedItems = w[0].CounteNumberofExpiratedItems();

            w[1] = InitialWarehouse("Warehouseitems2.txt", "warehouse2");
            w[1].totalExpiratedItems = w[1].CounteNumberofExpiratedItems();

            Console.Out.WriteLine("w1.totalExpiratedItems: {0}", w[0].totalExpiratedItems);
            Console.Out.WriteLine("w2.totalExpiratedItems: {0}", w[1].totalExpiratedItems);
            return w;
        }
        public static int RejectItemIn()
        {
            InventoryItem newItem = new InventoryItem();
            Warehouse w = new Warehouse();
            newItem.SetItem("bouncer", 220.0, 7, (DateTime.Parse("1/1/2014")).Date );
            w = InitialWarehouse("Items.txt", "warehouse1");
            int actualCounter = w.AddItemsInLocation(newItem);
            Console.Out.WriteLine("new item:{0},{1},{2},{3}", newItem.itemName, newItem.itemPrice, newItem.location, newItem.expirationDate);
            return actualCounter;
        }
    }
}
