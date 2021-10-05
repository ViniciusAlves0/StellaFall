using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YourScore : MonoBehaviour
{
    private TextMeshProUGUI scoreGOText;

    void Update()
    {
        scoreGOText.text = DATA.Valor.ToString();
        Debug.Log(DATA.Valor);
    }
}
