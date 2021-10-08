using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject pause;
    [SerializeField] private Move move;

    private void Start()
    {
        InvokeRepeating("ValorNovo", 1f, 0.4f);
        scoreText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(SlowUpdate());
    }

    IEnumerator SlowUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            scoreText.text = DATA.Valor.ToString();
        }

        Debug.Log(DATA.Valor);
    }

    private void ValorNovo()
    {
        if (pause.activeInHierarchy || move.dead)
        {
            DATA.Valor += 0;
        }
        else
        {
            DATA.Valor += 10;
        }
    }
}
