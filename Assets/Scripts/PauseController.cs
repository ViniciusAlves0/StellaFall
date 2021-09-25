using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseController : MonoBehaviour
{

    public GameObject pausePanel;
    public bool pausado = false;

    public void PauseGame()
        {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
        }


    public void ResumeGame()
        {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
        }

    public void Menu (string menu)
    {
        SceneManager.LoadScene(menu);
        Time.timeScale = 1f;
        pausado = false;
    }


}

