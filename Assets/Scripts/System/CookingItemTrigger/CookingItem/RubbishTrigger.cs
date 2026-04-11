using System.Collections;
using System.Collections.Generic;
using System.CookingItemTrigger;
using UnityEngine;

public class RubbishTrigger : CookingItemParent
{
    protected override void InteractionItem()
    {
       Debug.Log("Rubbish Trigger");
    }
}
