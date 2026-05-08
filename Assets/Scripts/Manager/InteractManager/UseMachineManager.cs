using System;
using UnityEngine;

namespace Manager.InteractManager
{
    public class UseMachineManager : OpenIconTriggerManager
    {
        public GameObject pastryBoard;
        public GameObject cuttingBoard;
        public GameObject burnishBoard;
        public GameObject rubbishBin1;
        public GameObject rubbishBIn2;
        
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
               case Type t when t == typeof(BurnisherTrigger):
                   burnishBoard.gameObject.SetActive(true);
                   break;
               case Type t when t == typeof(RubbishTrigger1):
                   rubbishBin1.gameObject.SetActive(true);
                   break;
               case Type t when t == typeof(RubbishTrigger2):
                   rubbishBIn2.gameObject.SetActive(true);
                   break;
           }
        }

        protected override void HideAllIcon()
        {
            pastryBoard.gameObject.SetActive(false);
            cuttingBoard.gameObject.SetActive(false);
            burnishBoard.gameObject.SetActive(false);
            rubbishBin1.gameObject.SetActive(false);
            rubbishBIn2.gameObject.SetActive(false);
            
        }
        
        protected override void SetType(Type type) => SwitchIcon(type);
        protected override void SetTriggerBool()=>HideAllIcon();
    }
}