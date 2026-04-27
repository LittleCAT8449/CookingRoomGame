using System.Collections.Generic;
using Event;
using UnityEngine;

namespace System.Coffee
{
    public class CoffeeCup : MonoBehaviour
    {
        [SerializeField] private List<CoffeeEventListener.E_DrinkIngredients> ingredientsList;
        
        private CoffeeEventListener.E_DrinkIngredients Eingredients;

        public IReadOnlyList<CoffeeEventListener.E_DrinkIngredients> IngredientsList => ingredientsList;

        


        public void AddIngredient(CoffeeEventListener.E_DrinkIngredients ingredient)
        {
            if (ingredientsList.Count < 5)
            {
                ingredientsList.Add(ingredient);
            }
            else
            {
                Debug.Log("杯子内容物已满");
            }
            
        }

        private void OnEnable()
        {
            CoffeeEventListener.st_selectIngredient += SetEingredient;
        }

        private void OnDisable()
        {
            CoffeeEventListener.st_selectIngredient -= SetEingredient;
        }

        private void SetEingredient(CoffeeEventListener.E_DrinkIngredients ingre)
        {
            Eingredients = ingre;
            AddIngredient(Eingredients);
        }

        public void ResetList()
        {
            ingredientsList.Clear();
        }
    }
}
