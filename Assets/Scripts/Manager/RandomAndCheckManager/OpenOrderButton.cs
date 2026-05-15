using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOrderButton : MonoBehaviour
{
    [SerializeField] private GameObject buttonObject;
    [SerializeField] private GameObject orderpage;

    public void ButtonClick()
    {
        orderpage.SetActive(true);
        buttonObject.SetActive(false);
    }

}
