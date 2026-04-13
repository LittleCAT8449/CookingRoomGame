using System.Collections;
using System.Collections.Generic;
using System.CookingItemTrigger;
using Manager.InventoryManager;
using UnityEngine;

public class FlourTrigger1 : CookingItemParent
{
   protected override void InteractionItem()
   {
      Inventory.Instance.AddItem(item);
      Debug.Log("Flour Trigger");
   }
}
