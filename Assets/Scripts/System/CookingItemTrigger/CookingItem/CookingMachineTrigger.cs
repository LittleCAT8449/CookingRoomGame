using System.Collections;
using System.Collections.Generic;
using System.CookingItemTrigger;
using UnityEngine;

public class CookingMachineTrigger : CookingItemParent
{
    [SerializeField] private GameObject cookingMachine;
    protected override void InteractionItem()
    {
        cookingMachine.SetActive(true);
    }
}
