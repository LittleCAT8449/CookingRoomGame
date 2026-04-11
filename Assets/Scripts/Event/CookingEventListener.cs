using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingEventListener
{
   public static event Action<Vector2> st_vector;
   

   public static void st_OnVectorChange(Vector2 x)
   {
      st_vector?.Invoke(x);
   }

   
   
}
