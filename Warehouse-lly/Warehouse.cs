using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryItemNS;

namespace Warehouse_lly
{
   
      static class Constants
    {
        public const int LocationNumbers = 10;

    }
    public class Warehouse : Warehouse_lly.IWarehouse
    {
        private double m_totalItems = 0;
        private double m_totalExpiratedItems = 0;
        private string m_wName=null;
        public Location[] location = new Location[Constants.LocationNumbers];

        public Warehouse()
        {

        }
        public double totalItems
        {
            get { return m_totalItems; }
            set { m_totalItems = value; }
        }
        public double totalExpiratedItems
        {
            get {return m_totalExpiratedItems; }
            set { m_totalExpiratedItems = value; }
        }
        public string wName
        {
            get { return m_wName; }
            set { m_wName = value; }
        }
        public double CounteTotalItems() 
      {        
          for(int i=0; i< Constants.LocationNumbers; i++)
         {
             m_totalItems += location[i].CounteItems();//location[i].itemsList );  
         }
        return m_totalItems;
      }
      public double CounteNumberofExpiratedItems()
      {
          for (int i = 0; i < Constants.LocationNumbers; i++)
          {
              m_totalExpiratedItems += location[i].CounteExpiratedItems();//(location[i].itemsList );

          }
          return m_totalExpiratedItems;
      }

      public int AddItemsInLocation(InventoryItem newItem)
      {
          location[newItem.location].AddItemIn(newItem);//, location[newItem.location].itemsList);
          return location[newItem.location].itemsList.Count ;
      }
      public int RemoveItemsFromLocation(InventoryItem item)
      {
          location[item.location].RemoveItemsOut(item);//, location[item.location].itemsList);
          return location[item.location].itemsList.Count;
      }
   }
}


