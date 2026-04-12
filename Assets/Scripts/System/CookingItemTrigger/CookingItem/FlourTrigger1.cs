using System.Collections;
using System.Collections.Generic;
using System.CookingItemTrigger;
using UnityEngine;

public class FlourTrigger1 : CookingItemParent
{
   protected override void InteractionItem()
   {
      Debug.Log("Flour Trigger");
   }
}
