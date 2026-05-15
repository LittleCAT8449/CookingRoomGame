using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceLoder : MonoBehaviour
{
    public string nextScenceName = "Game";

    public void LoadNextScence()
    {
        SceneManager.LoadScene(nextScenceName, LoadSceneMode.Single);
    }
}
