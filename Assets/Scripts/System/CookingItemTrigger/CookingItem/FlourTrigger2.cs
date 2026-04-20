using System.Collections;
using System.Collections.Generic;
using System.CookingItemTrigger;
using Manager.InventoryManager;
using UnityEngine;

public class FlourTrigger2 : CookingItemParent
{
   protected override void InteractionItem()
   {
      Inventory.Instance.AddItem(item);
   }
}
