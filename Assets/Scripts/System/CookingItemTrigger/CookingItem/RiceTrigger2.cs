using System.Collections;
using System.Collections.Generic;
using System.CookingItemTrigger;
using Manager.InventoryManager;
using UnityEngine;

public class RiceTrigger2 : CookingItemParent
{
    protected override void InteractionItem()
    {
        Inventory.instance.AddItem(item);
        Debug.Log("Rice Trigger");
    }
}
