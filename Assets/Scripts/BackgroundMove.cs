using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private Transform[] background;
    [SerializeField] private Vector2 velY;
    [SerializeField] private float height;

    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {
        foreach (Transform back in background)
        {
           if(back.transform.position.y > height * background.Length/2)
            {
                back.transform.Translate(new Vector2(0, height * (background.Length/2) * -2));
            }
            
            back.Translate(velY * Time.deltaTime);
        }
    }
}
