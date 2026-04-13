using System;
using System.CookingItemTrigger;
using UnityEngine;

namespace Manager.InteractManager
{
    public class FoodItem : OpenIconTriggerManager
    {
        public GameObject apple;
        public GameObject tomato;
        public GameObject potato;
        public GameObject pumpkin;
        public GameObject carrot;
        public GameObject murshroom;
        public GameObject cucumber;
        public GameObject cheese;
        public GameObject noodles;
        public GameObject rice1;
        public GameObject rice2;
        public GameObject flour1;
        public GameObject flour2;
        
        
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
                case Type t when t == typeof(AppleTrigger):
                    apple.SetActive(true);
                    Debug.Log("Apple");
                    break;
                case Type t when t == typeof(TomatoTrigger):
                    tomato.SetActive(true);
                    Debug.Log("Tomato");
                    break;
                case Type t  when t == typeof(PotatoTrigger):
                    potato.SetActive(true);
                    Debug.Log("Potato");
                    break;
                case Type t when t == typeof(PumpkinTrigger):
                    pumpkin.SetActive(true);
                    Debug.Log("Pumpkin");
                    break;
                case Type t  when t == typeof(CarrotTrigger):
                    carrot.SetActive(true);
                    Debug.Log("Carrot");
                    break;
                case Type t when t  == typeof(MurshroomTrigger):
                    murshroom.SetActive(true);
                    Debug.Log("Murshroom");
                    break;
                case Type t when  t == typeof(CheeseTrigger):
                    cheese.SetActive(true);
                    Debug.Log("Cheese");
                    break;
                case Type t when t == typeof(Cucumbertrigger):
                    cucumber.SetActive(true);
                    Debug.Log("Cucumber");
                    break;
                case Type t when t == typeof(NoodlesTrigger):
                    noodles.SetActive(true);
                    Debug.Log("Noodles");
                    break;
                case Type t when t ==typeof(RiceTrigger1):
                    rice1.SetActive(true);
                    Debug.Log("Rice1");
                    break;
                case Type t when  t == typeof(RiceTrigger2):
                    rice2.SetActive(true);
                    Debug.Log("Rice2");
                    break;
                case Type t when t == typeof(FlourTrigger1):
                    flour1.SetActive(true);
                    Debug.Log("Flour1");
                    break;
                case Type t when t == typeof(FlourTrigger2):
                    flour2.SetActive(true);
                    Debug.Log("Flour2");
                    break;
                case Type t when t ==typeof(CuttingBoardTrigger):
                    break;
                default:
                    Debug.LogError(type.ToString());
                    break;
            }
            
        }
        
        protected override void HideAllIcon()
        {
            apple.SetActive(false);
            tomato.SetActive(false);
            potato.SetActive(false);
            pumpkin.SetActive(false);
            carrot.SetActive(false);
            murshroom.SetActive(false);
            cucumber.SetActive(false);
            cheese.SetActive(false);
            noodles.SetActive(false);
            rice1.SetActive(false);
            rice2.SetActive(false);
            flour1.SetActive(false);
            flour2.SetActive(false);
        }
        
        protected override void SetType(Type type) => SwitchIcon(type);
        protected override void SetTriggerBool()=>HideAllIcon();
        
    }
}