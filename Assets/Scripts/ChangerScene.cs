using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangerScene : MonoBehaviour
{

    public string nomeCena;

    private Animator começa;

    public void ChangeS(string gameplay)
    {
        nomeCena = gameplay;
        StartCoroutine("Abrir");

    }

    private IEnumerator Abrir()
    {
        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene(nomeCena);
    }
       

    public void Sair()
    {
        Application.Quit();
    }

}
