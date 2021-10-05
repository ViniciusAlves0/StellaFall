using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    [SerializeField] public GameObject obs;
    [SerializeField] public GameObject obs2;
    [SerializeField] private Move player;
    [SerializeField] private Score scoreRef;

    [SerializeField] public float heightObs;

    [SerializeField] public Vector2 randomPositionX;
    [SerializeField] public Vector2 randomPositionY;

    [SerializeField] public Vector2 randomPositionY2;

    public float newPositionX;
    public float newPositionY;

    public float newPositionX2;
    public float newPositionY2;

    private float secondsSpawn;

    public GameObject newStar;
    public GameObject newStar2;

    private float chance;
   
    private float posX2R;
    public float posX2;

    void Start()
    {
        secondsSpawn = 1f;
        
        newPositionX = obs.transform.localPosition.x;
        newPositionY = obs.transform.localPosition.y;

        newPositionX2 = obs2.transform.localPosition.x;
        newPositionY2 = obs2.transform.localPosition.y;

        StartCoroutine(SlowUpdate());

        InvokeRepeating("SecondsAumento", 1f, 20f);
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

            chance = Random.Range(0, 5);

            posX2R = Random.Range(1, 3);

            if (posX2R == 1) posX2 = -2.7f;
            else posX2 = 2.7f;

            newPositionX = Random.Range(randomPositionX.x, randomPositionX.y);
            newPositionY = Random.Range(randomPositionY.x, randomPositionY.y);

            newPositionX2 = posX2;
            newPositionY2 = Random.Range(randomPositionY2.x, randomPositionY2.y);

            yield return StartCoroutine(Clone());

            if(DATA.Valor > 1000f) Star2();
        }
    }

    private IEnumerator Clone()
    {
        yield return newStar = Instantiate(obs, new Vector2(newPositionX, newPositionY), Quaternion.identity);
    }

    private IEnumerator Clone2()
    {
        yield return newStar2 = Instantiate(obs2, new Vector2(newPositionX2, newPositionY2), Quaternion.identity);
    }

    private float SecondsAumento()
    {

        if (secondsSpawn > 0.1f)
        {
            secondsSpawn -= 0.1f;
        }
        else secondsSpawn += 0;

        return secondsSpawn;
    }

    private void Star2()
    {
        if (chance < 2)
            StartCoroutine(Clone2());
        else return;
    }
}
