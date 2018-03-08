using System;
using InventoryItemNS;

namespace Warehouse_lly
{
    interface IWarehouse
    {
        int AddItemsInLocation(InventoryItem newItem);
        double CounteNumberofExpiratedItems();
        double CounteTotalItems();
        int RemoveItemsFromLocation(InventoryItem item);
        double totalExpiratedItems { get; set; }
        double totalItems { get; set; }
        string wName { get; set; }
    }
}
