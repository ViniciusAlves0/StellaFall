using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public string Gameplay;


    public void ChangeS()
    {
        SceneManager.LoadScene(Gameplay)
    }

    public void Sair()
    {
        Application.Quit();
    }
