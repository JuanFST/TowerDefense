using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";
    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
        Debug.Log("play");
    }

    public void Quit()
    {

        Debug.Log("quiting...");
        Application.Quit();
    }
}
