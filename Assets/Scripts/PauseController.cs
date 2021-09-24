using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    public GameObject pausePanel;
    public bool pause;

    public void PauseGame()
        {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
        }


    public void ResumeGame()
        {
        pause = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        }
}

