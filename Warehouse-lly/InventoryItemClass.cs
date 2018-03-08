using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data ;

namespace InventoryItemNS
{
    public class InventoryItem
    {
        private string m_itemName;
        public double itemPrice;
        public int location;
        private DateTime  m_expirationDate;
        private string m_storedTemperatureType;
        private DateTime m_shippedDate;
        public string itemName
        {
            get { return m_itemName; }
        }

        public DateTime  expirationDate
        {get
            { return m_expirationDate; }
        }

       
        public string storedTemperatureType
        {
            get { return m_storedTemperatureType; }
            set { m_storedTemperatureType = value; }
        }
        public DateTime shippedDate
        {
            get { return m_shippedDate; }
            set { m_shippedDate = value; }
        }

        public void SetItemStoredTemperature(string temp)
        {
            m_storedTemperatureType = temp;
        }

        public void SetItemShippedDate(DateTime date)
        {
            m_shippedDate = date ;
        }

   public InventoryItem()
    {
    }

    public void SetItem(string name, double price, int loc, DateTime  date )
    {
      m_itemName= name;
      itemPrice= price;
      location = loc;
      m_expirationDate = date.Date ;
      m_shippedDate = DateTime .Parse ("01/01/2015");
      m_storedTemperatureType = " ";
    }
    public override bool Equals(object obj)
    {
        //obj is null 
        if (obj == null)
        {
            return false;
        }

        //check if have an item
        if (obj is InventoryItem )
        {
            InventoryItem item = obj as InventoryItem;
            return item.m_itemName == this.m_itemName;
        }

        // not have an item
        else return false;
    }

    public override int GetHashCode()
    {

        return  (Convert.ToInt32(itemPrice)) ^ location;
        
    }
  }
}
