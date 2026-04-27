using System.CookingItemTrigger;
using UnityEngine;

public class CoffeeTrigger : CookingItemParent
{
    [SerializeField] private GameObject coffeePanel;
    
    protected override void InteractionItem()
    {
        if (coffeePanel != null)
        {
            coffeePanel.SetActive(true);
        }
    }
}
