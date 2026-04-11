using UnityEngine;

namespace System.CookingItemTrigger
{
    public class PotatoTrigger:CookingItemParent
    {
        
        protected override void InteractionItem()
        {
            Debug.Log("Potato Interact");
        }
        
    }
}