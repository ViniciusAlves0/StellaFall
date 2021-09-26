using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private float valor;

    [SerializeField] private GameObject pause;
    private Move player;

    private void Start()
    {

        scoreText = GetComponent<TextMeshProUGUI>();
        valor = 0;
    }
    void Update()
    {
        if(player.dead == false)
            InvokeRepeating("Valor", 01f, 0.4f);

        scoreText.text = valor.ToString();
    }

    private void Valor()
    {
        if (pause.activeInHierarchy)
        {
            valor += 0;
        }
        else
        {
            valor += 10;
        }
    }
}
