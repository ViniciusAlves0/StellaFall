using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private Transform[] background;
    [SerializeField] private Vector2 velY;
    [SerializeField] private float height;

    [SerializeField] private Vector2 randomPositionX;

    [SerializeField] private Vector2 randomPositionY;


    void Start()
    {
        
    }

    void Update()
    {
        foreach (Transform back in background)
        {
           if(back.transform.position.y > height * background.Length/2)
            {
                back.transform.Translate(new Vector2(0, height * (background.Length/2) * -2));

                if(CompareTag("Dead") && back.transform.position.y > height * background.Length / 2)
                {
                    float newPositionX = back.transform.localPosition.x;
                    
                    float newPositionY = back.transform.localPosition.y;

                    newPositionX = Random.Range(randomPositionX.x, randomPositionX.y);
                    newPositionY = Random.Range(randomPositionY.x, randomPositionY.y);

                    transform.localPosition = new Vector2(newPositionX, newPositionX);
                }
            }
            
            back.Translate(velY * Time.deltaTime);
        }
    }
}
