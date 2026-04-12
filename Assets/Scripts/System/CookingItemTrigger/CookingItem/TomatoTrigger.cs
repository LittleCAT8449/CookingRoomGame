using UnityEngine;
using Manager.InventoryManager;

namespace System.CookingItemTrigger
{
    public class TomatoTrigger:CookingItemParent
    {
        protected override void InteractionItem()
        {
            Inventory.instance.AddItem(item);
            Debug.Log("Tomato Interact");
        }
        
        
    }
}