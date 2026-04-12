using Manager.InventoryManager;
using UnityEngine;

namespace System.CookingItemTrigger
{
    public class PumpkinTrigger:CookingItemParent
    {
        
        protected override void InteractionItem()
        {
            Inventory.instance.AddItem(item);
            Debug.Log("Pumpkin Interact");
        }
        
    }
}