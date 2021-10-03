using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    [SerializeField] private GameObject obs;
    [SerializeField] private Move player;

    [SerializeField] public float heightObs;


    [SerializeField] public Vector2 randomPositionX;
    [SerializeField] public Vector2 randomPositionY;

    public float newPositionX;
    public float newPositionY;

    public GameObject newStar;

    void Start()
    {
        newPositionX = obs.transform.localPosition.x;

        newPositionY = obs.transform.localPosition.y;

        StartCoroutine(SlowUpdate());
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
            yield return new WaitForSeconds(3f);

            newPositionX = Random.Range(randomPositionX.x, randomPositionX.y);
            newPositionY = Random.Range(randomPositionY.x, randomPositionY.y);

            yield return StartCoroutine(Clone());
        }
    }

    private IEnumerator Clone()
    {
        yield return newStar = Instantiate(obs, new Vector2(newPositionX, newPositionY), Quaternion.identity);
    }
}
