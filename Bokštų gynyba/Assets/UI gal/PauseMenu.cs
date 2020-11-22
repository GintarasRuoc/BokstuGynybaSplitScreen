using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public static bool GameIsPaused = false;
    public string ConX = "ConXP1";
    public string ConX2 = "ConXP2";

    //Pauses mygtukai
    public string GamePause = "Pause";

    void Update()
    {
        if (Input.GetButtonDown(GamePause))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (GameIsPaused)
        {
            if (Input.GetButtonDown(ConX) || Input.GetButtonDown(ConX2))
            {
                SceneManager.LoadScene(0);
                GameIsPaused = false;
}
        }
    }
    void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
