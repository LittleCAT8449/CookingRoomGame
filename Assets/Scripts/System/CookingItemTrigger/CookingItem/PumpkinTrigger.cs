using Manager.InventoryManager;
using UnityEngine;

namespace System.CookingItemTrigger
{
    public class PumpkinTrigger:CookingItemParent
    {
        
        protected override void InteractionItem()
        {
            Inventory.Instance.AddItem(item);
        }
        
    }
}