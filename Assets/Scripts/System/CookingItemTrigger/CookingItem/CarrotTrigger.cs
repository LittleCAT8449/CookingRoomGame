using System.Collections;
using System.Collections.Generic;
using System.CookingItemTrigger;
using UnityEngine;

public class CarrotTrigger : CookingItemParent
{
    protected override void InteractionItem()
    {
        Debug.Log("Carrot Interact");
    }
}
