using Manager.InventoryManager;
using UnityEngine;

namespace System.CookerInteract
{
    public class CuttingBoard : MonoBehaviour
    {
        
        public Item[] items;

        private void Awake()
        {
            items=Inventory.Instance.GetItems();
        }

        private void Update()
        {
            items=Inventory.Instance.GetItems();
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Pressed 1");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Pressed 2");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Pressed 3");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Debug.Log("Pressed 4");
            }
            
            
        }
    }
}