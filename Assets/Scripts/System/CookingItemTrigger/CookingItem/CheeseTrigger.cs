using System.Collections;
using System.Collections.Generic;
using System.CookingItemTrigger;
using UnityEngine;

public class CheeseTrigger : CookingItemParent
{
    protected override void InteractionItem()
    {
        Debug.Log("Cheese");
    }
}
