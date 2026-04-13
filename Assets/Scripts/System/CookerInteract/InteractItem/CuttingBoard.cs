using Manager.InventoryManager;
using UnityEngine;
using Utils;

namespace System.CookerInteract
{
    public class CuttingBoard : InteractCookerParent
    {
        public Item cuttingApple;
        public Item cuttingTomato;
        public Item cuttingCucumber;
        public Item cuttingCarrot;
        public Item cuttingMurshroom;
        public Item cuttingPotato;
        public Item cuttingPumpkin;
        
        private Item[] items;
        private Item item;

        private void Awake()
        {
            items=Inventory.Instance.GetItems();
        }

        private void Update()
        {
            
            PressNumber();
            
        }

        public override void PressNumber()
        {
            items=Inventory.Instance.GetItems();
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CuttingBoardRecipe(items[0],0);
                Debug.Log("Pressed 1"+items[0].name);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CuttingBoardRecipe(items[1],1);
                Debug.Log("Pressed 2"+items[1].name);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CuttingBoardRecipe(items[2],2);
                Debug.Log("Pressed 3"+items[2].name);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                CuttingBoardRecipe(items[3],3);
                Debug.Log("Pressed 4"+items[3].name);
            }
        }
        
        

        private void CuttingBoardRecipe(Item item,int index)
        {

            if (item != null)
            {
               string itemName = item.name;

               switch (itemName)
               {
                   case "apple":
                       SetInventory(index,cuttingApple);
                       Debug.Log("Set Cutting Apple");
                       break;
                   case "tomato":
                       SetInventory(index,cuttingTomato);
                       Debug.Log("Set Cutting Tomato");
                       break;
                   case "cucumber":
                       SetInventory(index,cuttingCucumber);
                       Debug.Log("Set Cutting Cucumber");
                       break;
                   case "carrot":
                       SetInventory(index,cuttingCarrot);
                       Debug.Log("Set Cutting Carrot");
                       break;
                   case "murshroom":
                       SetInventory(index,cuttingMurshroom);
                       Debug.Log("Set Cutting Murshroom");
                       break;
                   case  "potato":
                       SetInventory(index,cuttingPotato);
                       Debug.Log("Set Cutting Potato");
                       break;
                   case "pumpkin":
                       SetInventory(index,cuttingPumpkin);
                       Debug.Log("Set Cutting Pumpkin");
                       break;
                       
                   
               }
               
            }
            
        }

        


    }
}