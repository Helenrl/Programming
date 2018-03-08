using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryItemNS;


namespace Warehouse_lly
{
   
    public  class Location : ILocation
    {
       public  List<InventoryItem> itemsList = new List<InventoryItem>();

       public Location()
       {

       }
        public virtual void AddItemIn(InventoryItem newItem)
        {
            InventoryItem items = new InventoryItem();
            foreach (InventoryItem item in itemsList)
                if (item.itemName != newItem.itemName)
                {
                    itemsList.Add(newItem);
                    break;
                }
                else if (item.itemName == newItem.itemName)
                    if (DateTime.Compare(newItem.expirationDate, item.expirationDate) == 0)
                    {
                        itemsList.Add(newItem);
                        break;
                    }
                    else
                    {
                        Console.Out.WriteLine("The item could not be added into Location");
                        break;
                    }
        }
        public virtual void RemoveItemsOut(InventoryItem targetItem)
        {
            if( itemsList .Contains (targetItem))
               itemsList.Remove(targetItem );
        }
        public double CounteItems()
        {
            return itemsList.Count();
        }

        public double CounteExpiratedItems()
        {
            double counterOfExpiratedItems = 0;
            foreach (InventoryItem item in itemsList)
                if (DateTime.Compare(item.expirationDate, DateTime.Today) < 0)
                    counterOfExpiratedItems++;
            return counterOfExpiratedItems;
        }
    }
}
