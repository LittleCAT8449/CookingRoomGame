using System.Collections;
using System.Collections.Generic;
using System.CookingItemTrigger;
using Manager.InventoryManager;
using UnityEngine;

public class CheeseTrigger : CookingItemParent
{
    protected override void InteractionItem()
    {
        Inventory.Instance.AddItem(item);
        Debug.Log("Cheese");
    }
}
