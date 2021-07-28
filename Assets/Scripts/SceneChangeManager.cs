using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChangeManager : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    static void FirstLoad()
    {
        if (SceneManager.GetActiveScene().name.CompareTo("Lobby") != 0)
            SceneManager.LoadScene("Lobby");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MapDesign");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");

    }
}