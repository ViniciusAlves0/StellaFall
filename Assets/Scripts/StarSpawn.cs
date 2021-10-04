using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    [SerializeField] public GameObject obs;
    [SerializeField] private Move player;

    [SerializeField] public float heightObs;


    [SerializeField] public Vector2 randomPositionX;
    [SerializeField] public Vector2 randomPositionY;

    public float newPositionX;
    public float newPositionY;

    private float secondsSpawn;

    public GameObject newStar;

    void Start()
    {
        secondsSpawn = 1f;
        
        newPositionX = obs.transform.localPosition.x;

        newPositionY = obs.transform.localPosition.y;

        StartCoroutine(SlowUpdate());

        InvokeRepeating("secondsAumento", 1f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.dead)
        {
            StopAllCoroutines();
            return;
        }
    }

    IEnumerator SlowUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsSpawn);

            newPositionX = Random.Range(randomPositionX.x, randomPositionX.y);
            newPositionY = Random.Range(randomPositionY.x, randomPositionY.y);

            yield return StartCoroutine(Clone());
        }
    }

    private IEnumerator Clone()
    {
        yield return newStar = Instantiate(obs, new Vector2(newPositionX, newPositionY), Quaternion.identity);
    }

    private float secondsAumento()
    {

        if (secondsSpawn > 0.1f)
        {
            secondsSpawn -= 0.1f;
        }
        else secondsSpawn += 0;

        return secondsSpawn;
    }
}
