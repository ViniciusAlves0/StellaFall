using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Obstacles : MonoBehaviour
{
    [SerializeField] private GameObject obs;
    [SerializeField] private Move player;
    [SerializeField] private float heightObs;
    
    [SerializeField] private Vector2 velY;

    [SerializeField] private Vector2 randomPositionX;

    [SerializeField] private Vector2 randomPositionY;

    float newPositionX;
    float newPositionY;

    private void Start()
    {
        newPositionX = obs.transform.localPosition.x;

        newPositionY = obs.transform.localPosition.y;

        StartCoroutine(SlowUpdate());
    }

    void Update()
    {
        if (player.dead)
        {  
            StopAllCoroutines();
            return; 
        }

        obs.transform.Translate(velY * Time.deltaTime);

    }

    IEnumerator SlowUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            newPositionX = Random.Range(randomPositionX.x, randomPositionX.y);
            newPositionY = Random.Range(randomPositionY.x, randomPositionY.y);

            yield return new WaitForSeconds(3);
            StartCoroutine(Clone());

            if (obs.transform.position.y > heightObs * 2)
            {
                Destroy(obs);
            }

        }
    }

    private IEnumerator Clone()
    {
        yield return new WaitForSeconds(3);

        Instantiate(obs, new Vector2(newPositionX, newPositionY), Quaternion.identity);
    }
}

