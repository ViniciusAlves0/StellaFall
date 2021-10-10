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

        if (name == "Star 2")
        {
            StarVel2();
            transform.Translate(velY * Time.deltaTime);
        }
        
        if (transform.position.y > spawn.heightObs * 2)
        {
            if (name == "Star 1" || name == "Star 2")
            {
                return;
            }
            else Destroy(gameObject);
        }
    }

    private void Colidiu()
    {
        spawn.newStar = Instantiate(spawn.obs, new Vector2(spawn.newPositionX, spawn.newPositionY), Quaternion.identity);

        Destroy(gameObject);
    }

    private void Colidiu2()
    {
        spawn.newStar2 = Instantiate(spawn.obs2, new Vector2(spawn.newPositionX2, spawn.newPositionY2), Quaternion.identity);

        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(name == "Star 1") Colidiu();
        else if(name == "Star 2") Colidiu2();
    }


    private void Aumento()
    {
        if (velY.y <= aumento.limiteVelY.y)
        {
            velY += new Vector2(0.5f, 2f) * 0.3f;
        }
        else velY = aumento.limiteVelY;
    }

    private void StarVel2()
    {
        if (spawn.posX2 > 0)
        {
            velY = new Vector2(velY.x * -1, velY.y);
        }
        else velY = new Vector2(velY.x * 1, velY.y);
    }
}

