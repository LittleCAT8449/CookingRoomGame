using System.CookerInteract;
using System.CookingItemTrigger;
using UnityEngine;

public class PotTrigger2 : CookingItemParent
{
    public Pot targetPot;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Player"))
        {
            Pot.currentFocusedPot = targetPot;
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if (other.CompareTag("Player") && Pot.currentFocusedPot == targetPot)
        {
            Pot.currentFocusedPot = null;
        }
    }

    protected override void InteractionItem()
    {
        if (targetPot != null)
            targetPot.Interact();
    }
}