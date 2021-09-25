using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public float valor;

    [SerializeField] private GameObject pause;

    private void Start()
    {

        InvokeRepeating("Valor", 01f, 0.3f);

        scoreText = GetComponent<TextMeshProUGUI>();
        valor = 0;
    }
    void Update()
    {
        Valor();
        scoreText.text = valor.ToString();

    }

    public void Valor()
    {
        if (pause.activeInHierarchy == true)
            valor += 0;
        else valor += 1;
    }
}
