using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.Play("TitleMusic");

    }
    public void StartGame()
    {
        GameManager.instance.StartGame();
        AudioManager.instance.Stop("TitleMusic");
        AudioManager.instance.Play("GameMusic");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

