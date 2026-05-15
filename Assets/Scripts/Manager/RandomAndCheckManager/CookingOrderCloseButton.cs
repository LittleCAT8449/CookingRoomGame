using UnityEngine;

namespace Manager.RandomAndCheckManager
{
    public class CookingOrderCloseButton : MonoBehaviour
    {
        [SerializeField] private GameObject targetPage;
        [SerializeField] private GameObject orderButton;

        public void ButtonClick()
        {
            if (targetPage != null)
                targetPage.SetActive(false);
            orderButton.SetActive(true);
        }
    }
}