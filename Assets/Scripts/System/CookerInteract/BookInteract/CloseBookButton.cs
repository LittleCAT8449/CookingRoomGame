using UnityEngine;

namespace System.CookerInteract.BookInteract
{
    public class CloseBookButton : MonoBehaviour
    {
        [SerializeField] private GameObject bookRecipe;

        public void ButtonClick()
        {
            bookRecipe.SetActive(false);
        }
    }
}