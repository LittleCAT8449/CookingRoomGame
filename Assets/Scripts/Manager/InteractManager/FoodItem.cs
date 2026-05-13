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
        
        public GameObject cuttingBoard;
        public GameObject pastry;
        public GameObject burnish;
        public GameObject pot1;
        public GameObject pot2;
        public GameObject pot3;
        public GameObject coffee;
        
        
        
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
                    
                    break;
                case Type t when t == typeof(TomatoTrigger):
                    tomato.SetActive(true);
                    
                    break;
                case Type t  when t == typeof(PotatoTrigger):
                    potato.SetActive(true);
                    
                    break;
                case Type t when t == typeof(PumpkinTrigger):
                    pumpkin.SetActive(true);
                    
                    break;
                case Type t  when t == typeof(CarrotTrigger):
                    carrot.SetActive(true);
                    
                    break;
                case Type t when t  == typeof(MurshroomTrigger):
                    murshroom.SetActive(true);
                    
                    break;
                case Type t when  t == typeof(CheeseTrigger):
                    cheese.SetActive(true);
                    
                    break;
                case Type t when t == typeof(Cucumbertrigger):
                    cucumber.SetActive(true);
                    
                    break;
                case Type t when t == typeof(NoodlesTrigger):
                    noodles.SetActive(true);
                    
                    break;
                case Type t when t ==typeof(RiceTrigger1):
                    rice1.SetActive(true);
                    
                    break;
                case Type t when  t == typeof(RiceTrigger2):
                    rice2.SetActive(true);
                    
                    break;
                case Type t when t == typeof(FlourTrigger1):
                    flour1.SetActive(true);
                    
                    break;
                case Type t when t == typeof(FlourTrigger2):
                    flour2.SetActive(true);
                    
                    break;
                case Type t when t == typeof(CuttingBoardTrigger):
                    cuttingBoard.SetActive(true);
                    break;
                case Type t when t == typeof(PastryBoardTrigger):
                    pastry.SetActive(true);
                    break;
                case Type t when t == typeof(BurnisherTrigger):
                    burnish.SetActive(true);
                    break;
                case Type t when t == typeof(PotTrigger):
                    pot1.SetActive(true);
                    break;
                case Type t when t == typeof(PotTrigger1):
                    pot2.SetActive(true);
                    break;
                case Type t when t ==typeof(PotTrigger2) :
                    pot3.SetActive(true);
                    break;
                case Type t when t == typeof(CoffeeTrigger):
                    coffee.SetActive(true);
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
            cuttingBoard.SetActive(false);
            pastry.SetActive(false);
            burnish.SetActive(false);
            pot1.SetActive(false);
            pot2.SetActive(false);
            pot3.SetActive(false);
            coffee.SetActive(false);
        }
        
        protected override void SetType(Type type) => SwitchIcon(type);
        protected override void SetTriggerBool()=>HideAllIcon();
        
    }
}