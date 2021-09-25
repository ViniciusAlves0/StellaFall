using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public float valor;
    private Move player;

    [SerializeField] private GameObject pause;

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
        if (pause.activeInHierarchy == true)
            valor += 0;
        else valor += 10;
    }
}
