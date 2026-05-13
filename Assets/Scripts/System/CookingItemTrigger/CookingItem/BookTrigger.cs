using System.CookingItemTrigger;
using UnityEngine;

public class BookTrigger : CookingItemParent
{
    [SerializeField] private GameObject bookRecipe;
    protected override void InteractionItem()
    {
        bookRecipe.SetActive(true);
        
    }
}