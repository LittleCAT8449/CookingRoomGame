using Event;
using UnityEngine;

namespace Manager.RandomAndCheckManager
{
    public class PressNumberButton : MonoBehaviour
    {
        [SerializeField] private int number;

        public void ButtonClick()
        {
            PressNumberListener.st_OnPressNumber(number);
        }
        
    }
}