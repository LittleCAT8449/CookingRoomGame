using UnityEngine;

namespace System.Coffee
{
    public class CoffeeRecipe : MonoBehaviour
    {
        [SerializeField] private GameObject recipe;
        [SerializeField] private GameObject makingCoffee;
        [SerializeField] private GameObject resultCoffee;
        public void OnClick()
        {
            makingCoffee.SetActive(false);
            resultCoffee.SetActive(false);
            recipe.gameObject.SetActive(true);
        }
    }
}