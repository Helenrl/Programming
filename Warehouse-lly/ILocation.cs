using System;
using InventoryItemNS;

namespace Warehouse_lly
{
    public interface ILocation
    {
        void AddItemIn(InventoryItem newItem);
        double CounteExpiratedItems();
        double CounteItems();
        void RemoveItemsOut(InventoryItem targetItem);
    }
}
