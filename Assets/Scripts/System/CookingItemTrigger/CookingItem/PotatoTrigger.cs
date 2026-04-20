using Manager.InventoryManager;
using UnityEngine;

namespace System.CookingItemTrigger
{
    public class PotatoTrigger:CookingItemParent
    {
        
        protected override void InteractionItem()
        {
            Inventory.Instance.AddItem(item);
        }
        
    }
}