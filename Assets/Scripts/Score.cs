using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private float valor;

    private void Start()
    {
        InvokeRepeating("Valor", 01f, 0.5f);

        scoreText = GetComponent<TextMeshProUGUI>();
        valor = 0;
    }
    void Update()
    {
        Valor();
        scoreText.text = valor.ToString();
    }

    private void Valor()
    {
        valor += 1;
    }
}
