using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincSong : MonoBehaviour
{
    [SerializeField] private GameObject[] Musica;

    private void Awake()
    {
        Musica = GameObject.FindGameObjectsWithTag("Music");

        if (Musica.Length >= 2)
        {
            Destroy(Musica[1]);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Awake();
    }
}
