using System;
using Manager.InventoryManager;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Manager.InteractManager
{
    public class CuttingBoard : OpenIconTriggerManager
    {
        [Header("UI")]
        public Item apple;
        public Item carrot;
        public Item cucumber;
        public Item murshroom;
        public Item potato;
        public Item pumpkin;
        public Item tomato;

        [Header("Objects")] 
        public GameObject backGround;
        
        public GameObject appleObejct;
        public GameObject carrotObejct;
        public GameObject murshroomObejct;
        public GameObject potatoObejct;
        public GameObject tomatoObejct;
        public GameObject pumpkinObejct;
        public GameObject cucumberObejct;

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
                case Type t when t ==typeof(CuttingBoardTrigger):
                    if (Inventory.instance.HasItem(apple))
                    {
                        appleObejct.SetActive(true);
                        backGround.SetActive(true);
                    }
                    break;
                default:
                    break;
            }
            
        }

        protected override void HideAllIcon()
        {
            backGround.SetActive(false);
            appleObejct.SetActive(false);
            carrotObejct.SetActive(false);
            murshroomObejct.SetActive(false);
            potatoObejct.SetActive(false);
            tomatoObejct.SetActive(false);
            pumpkinObejct.SetActive(false);
            cucumberObejct.SetActive(false);
        }
        
        protected override void SetType(Type type) => SwitchIcon(type);
        protected override void SetTriggerBool()=>HideAllIcon();
        
    }
}