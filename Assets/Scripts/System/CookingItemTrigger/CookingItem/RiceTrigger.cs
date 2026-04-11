using System.Collections;
using System.Collections.Generic;
using System.CookingItemTrigger;
using UnityEngine;

public class RiceTrigger : CookingItemParent
{
    protected override void InteractionItem()
    {
        Debug.Log("Rice Trigger");
    }
}
