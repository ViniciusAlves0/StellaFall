using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DATA : MonoBehaviour
{
    public static float Valor;
    public static float Cut;
    [SerializeField] private GameObject[] Datas;

    private void Awake()
    {
        if(Datas.Length >= 2)
        {
            Destroy(Datas[0]);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Awake();
    }
}
