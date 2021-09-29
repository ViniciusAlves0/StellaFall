using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private float valor;

    [SerializeField] private GameObject pause;
    [SerializeField] private Move move;

    private void Start()
    {
        InvokeRepeating("Valor", 01f, 0.4f);
        scoreText = GetComponent<TextMeshProUGUI>();
        valor = 0;
    }
    void Update()
    {

        scoreText.text = valor.ToString();
    }

    private void Valor()
    {
        if (pause.activeInHierarchy || move.dead)
        {
            valor += 0;
        }
        else
        {
            valor += 10;
        }
    }
}
