using Manager.InventoryManager;
using Unity.VisualScripting;
using UnityEngine;
using Utils;

namespace System.CookingItemTrigger
{
    public class AppleTrigger : CookingItemParent
    {
        
        protected override void InteractionItem()
        {
            Inventory.instance.AddItem(item);
            Debug.Log("Apple Interact");
        }

        
    }
}