using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PastryBar : MonoBehaviour
{
    public GameObject UI;
    public static PastryBar Instance;
    public int maxMakingBar;
    private int currentMakingBar;

    public bool setMakingStart;

    public Image makingBar;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        setMakingStart = false;
        currentMakingBar = 0;
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        makingBar.fillAmount=(float)currentMakingBar / maxMakingBar;
        if (Input.GetKeyDown(KeyCode.C)&&setMakingStart)
        {
            currentMakingBar++;
        }

        if (currentMakingBar == maxMakingBar)
        {
            Debug.Log("Making Successful");
            currentMakingBar = 0;
            setMakingStart = false;
            UI.SetActive(false);
            CookingEventListener.st_doughMakingDone();
        }
    }

    

    public int getCurrentValue()
    {
        return currentMakingBar;
    }

    public void setUIActive() => UI.SetActive(true);
}
