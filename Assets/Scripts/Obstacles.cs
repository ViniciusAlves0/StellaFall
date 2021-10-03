using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Obstacles : MonoBehaviour
{
    [SerializeField] private GameObject obs;
    [SerializeField] private Move player;
    [SerializeField] private StarSpawn spawn;

    [SerializeField] private Vector2 velY;

    private void Start()
    {

    }

    void Update()
    {
        if (player.dead)
        {  
            return; 
        }

        obs.transform.Translate(velY * Time.deltaTime);

        if (obs.transform.position.y > spawn.heightObs * 2)
        {
            if (obs.name == "Star 1")
            {
                return;
            }
            else Destroy(obs);
        }

    }

    private void Colidiu()
    {
        Destroy(obs);

        spawn.newStar = Instantiate(obs, new Vector2(spawn.newPositionX, spawn.newPositionY), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            Colidiu();
        }
    }
}

