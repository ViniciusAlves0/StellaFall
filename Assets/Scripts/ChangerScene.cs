using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangerScene : MonoBehaviour
{
    public PauseController pauseRef;

    public void ChangeS(string gameplay)
    {
        SceneManager.LoadScene(gameplay);
        pauseRef.pausePanel.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }

}
