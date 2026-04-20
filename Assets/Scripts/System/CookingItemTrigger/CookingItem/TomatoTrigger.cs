using UnityEngine;
using Manager.InventoryManager;

namespace System.CookingItemTrigger
{
    public class TomatoTrigger:CookingItemParent
    {
        protected override void InteractionItem()
        {
            Inventory.Instance.AddItem(item);
        }
        
        
    }
}