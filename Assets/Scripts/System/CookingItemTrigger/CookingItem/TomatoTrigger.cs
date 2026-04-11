using UnityEngine;

namespace System.CookingItemTrigger
{
    public class TomatoTrigger:CookingItemParent
    {
        protected override void InteractionItem()
        {
            Debug.Log("Tomato Interact");
        }
        
        
    }
}