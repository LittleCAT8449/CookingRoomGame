using Event;
using UnityEngine;
using UnityEngine.UI;

namespace System.Coffee
{
    public class CoffeeIngredientUI : MonoBehaviour
    {
        [SerializeField] private int currentIndex;
        [SerializeField] private CoffeeCup coffeeCup;
        [SerializeField] private Image ingredientIcon;
        [SerializeField] private Sprite milkSprite;
        [SerializeField] private Sprite coffeeSprite;
        [SerializeField] private Sprite waterSprite;
        [SerializeField] private Sprite cocoSprite;
        [SerializeField] private Sprite bubblesSprite;
        [SerializeField] private Sprite emSprite;
        private Sprite targetSprite;

        private void Start()
        {
            ResetIngredient();
        }

        private void Update()
        {
            CheckIngredient(currentIndex);
            ingredientIcon.sprite = targetSprite;
        }


        private void CheckIngredient(int index)
        {
            if (coffeeCup == null) return;
            var list = coffeeCup.IngredientsList;
            if (list == null || index < 0 || index >= list.Count) return;

            var ingredient = list[index];
            
            switch (ingredient)
            {
                case CoffeeEventListener.E_DrinkIngredients.Milk:
                    targetSprite = milkSprite;
                    break;
                case CoffeeEventListener.E_DrinkIngredients.Coffee:
                    targetSprite = coffeeSprite;
                    break;
                case CoffeeEventListener.E_DrinkIngredients.Bubble:
                    targetSprite = bubblesSprite;
                    break;
                case CoffeeEventListener.E_DrinkIngredients.Coco:
                    targetSprite = cocoSprite;
                    break;
                case CoffeeEventListener.E_DrinkIngredients.Water:
                    targetSprite = waterSprite;
                    break;
                default:
                    targetSprite = null;
                    break;
            }
            if (ingredientIcon != null)
                ingredientIcon.sprite = targetSprite;
            
        }

        public void ResetIngredient()
        {
            coffeeCup.ResetList();
            targetSprite = emSprite;
        }

        private void OnEnable()
        {
            CoffeeEventListener.st_dropIngredient += ResetIngredient;
        }

        private void OnDisable()
        {
            CoffeeEventListener.st_dropIngredient -= ResetIngredient;
        }
    }
}