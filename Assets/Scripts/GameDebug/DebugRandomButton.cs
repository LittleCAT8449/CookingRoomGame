using Manager.RandomAndCheckManager;
using UnityEngine;

namespace GameDebug
{
    public class DebugRandomButton : MonoBehaviour
    {

        public RandomCookingOrder cookingOrder;
        
        public void ButtonClick()
        {
            cookingOrder.RandomOrder();
        }
    }
}