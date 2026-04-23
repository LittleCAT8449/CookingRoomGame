using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingEventListener
{
   public static event Action<Vector2> st_vector;
   public static event Action<Type> st_enter_type;
   public static event Action st_exit_type;
   public static event Action st_doughMakingDone;
   public static event Action st_cuttingMakingSuccessful;
   public static event Action st_cuttingMakingFalse;
   public static event Action st_burnishMakingSuccessful;
   public static event Action st_burnishMakingFalse;
   
   

   public static void st_OnVectorChange(Vector2 x)
   {
      st_vector?.Invoke(x);
   }

   public static void st_OnEnterType(Type t)
   {
      st_enter_type?.Invoke(t);
   }

   public static void st_OnExitType()
   {
      st_exit_type?.Invoke();
   }

   public static void st_OndoughMakingDone()
   {
      st_doughMakingDone?.Invoke();
   }

   public static void st_OncuttingSuccessful()
   {
      st_cuttingMakingSuccessful?.Invoke();
   }

   public static void st_OncuttingFalse()
   {
      st_cuttingMakingFalse?.Invoke();
   }

   public static void st_OnBurnishSuccessful()
   {
      st_burnishMakingSuccessful?.Invoke();
   }

   public static void st_OnBurnishFalse()
   {
      st_burnishMakingFalse?.Invoke();
   }



}
