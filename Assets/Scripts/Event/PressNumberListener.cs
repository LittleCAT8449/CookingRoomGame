using System;
using UnityEngine;

namespace Event
{
    public class PressNumberListener
    {
        public static event Action<int> st_pressNumber;
        public static event Action<bool> st_confirm; 

        public static void st_OnPressNumber(int number)
        {
            st_pressNumber?.Invoke(number);
        }

        public static void st_OnPressConfirmButton(bool value)
        {
            st_confirm?.Invoke(value);
        }
    }
}