using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseController : MonoBehaviour
{

    public GameObject pausePanel;

    public void PauseGame()
        {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        }


    public void ResumeGame()
        {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        }

    public void Menu (string menu)
    {
        DATA.Valor = 0;
        SceneManager.LoadScene(menu);
        Time.timeScale = 1f;
    }


}

