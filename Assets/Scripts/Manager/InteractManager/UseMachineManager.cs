using System;
using UnityEngine;

namespace Manager.InteractManager
{
    public class UseMachineManager : OpenIconTriggerManager
    {
        public GameObject pastryBoard;
        public GameObject cuttingBoard;
        
        protected override void OnEnable()
        {
            CookingEventListener.st_enter_type += SetType;
            CookingEventListener.st_exit_type += SetTriggerBool;
        }

        protected override void OnDisable()
        {
            CookingEventListener.st_enter_type -= SetType;
            CookingEventListener.st_exit_type -= SetTriggerBool;
        }

        protected override void SwitchIcon(Type type)
        {
           HideAllIcon();
           switch (type)
           {
               case Type t when t == typeof(PastryBoardTrigger) :
                   pastryBoard.gameObject.SetActive(true);
                   break;
               case Type t when t == typeof(CuttingBoardTrigger):
                   cuttingBoard.gameObject.SetActive(true);
                   break;
           }
        }

        protected override void HideAllIcon()
        {
            pastryBoard.gameObject.SetActive(false);
            cuttingBoard.gameObject.SetActive(false);
        }
        
        protected override void SetType(Type type) => SwitchIcon(type);
        protected override void SetTriggerBool()=>HideAllIcon();
    }
}