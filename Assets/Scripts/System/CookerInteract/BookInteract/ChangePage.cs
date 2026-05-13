using UnityEngine;

namespace System.CookerInteract.BookInteract
{
    public class ChangePage : MonoBehaviour
    {

        [SerializeField] private GameObject rightPageIcon;
        [SerializeField] private GameObject leftPageIcon; 
        [SerializeField] private GameObject firstPage;
        [SerializeField] private GameObject nextPage;

        [SerializeField] private bool isRightTurn;

        public void ButtonClick()
        {
            if (isRightTurn)
            {
                
                firstPage.SetActive(false);
                leftPageIcon.SetActive(true);
                nextPage.SetActive(true);
                rightPageIcon.SetActive(false);
            }
            else
            {
                
                firstPage.SetActive(true);
                leftPageIcon.SetActive(false);
                nextPage.SetActive(false);
                rightPageIcon.SetActive(true);
            }
        }
    }
}