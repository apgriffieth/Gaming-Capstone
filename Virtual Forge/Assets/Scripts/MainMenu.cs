using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject quickplayCheck;

    public void PlayTutorial()
    {
        GameObject.Find("Quickplay/Tutorial").GetComponent<Quickplay_TutorialCheck>().isQuickplay = false;
        SceneManager.LoadScene(1);
    }

    public void PlayQuickPlay()
    {
        GameObject.Find("Quickplay/Tutorial").GetComponent<Quickplay_TutorialCheck>().isQuickplay = true;
        SceneManager.LoadScene(1);
    }

    public void PlayMultiplayer()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
