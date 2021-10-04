using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Obstacles : MonoBehaviour
{
    [SerializeField] private Move player;
    [SerializeField] private StarSpawn spawn;
    [SerializeField] private BackgroundMove aumento;

    [SerializeField] private Vector2 velY;

    private void Start()
    {
        InvokeRepeating("Aumento", 5f, 15f);
    }

    void Update()
    {
        if (player.dead)
        {  
            return; 
        }

       transform.Translate(velY * Time.deltaTime);

        if (transform.position.y > spawn.heightObs * 2)
        {
            if (name == "Star 1")
            {
                return;
            }
            else Destroy(gameObject);
        }

    }

    private void Colidiu()
    {
        Destroy(gameObject);

        Debug.Log("colidiuEstrela");

        spawn.newStar = Instantiate(spawn.obs, new Vector2(spawn.newPositionX, spawn.newPositionY), Quaternion.identity);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            Colidiu();
        }
    }

    private void Aumento()
    {
        if (velY.y <= aumento.limiteVelY.y)
            velY += new Vector2(0, 2) * 0.3f;
        else velY = aumento.limiteVelY;
    }
}

