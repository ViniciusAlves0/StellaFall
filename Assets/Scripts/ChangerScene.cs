using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangerScene : MonoBehaviour
{
    private Animator come�a;

    public void ChangeS(string gameplay)
    {
        SceneManager.LoadScene(gameplay);

    }

    public void Sair()
    {
        Application.Quit();
    }

}
