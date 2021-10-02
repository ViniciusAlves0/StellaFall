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

    private Vector2 limiteVelY;
    [SerializeField] private GameObject cut;

    private void Start()
    {
        limiteVelY = new Vector2(0, 35);

        InvokeRepeating("Aumento", 05f, 20f);
    }

    void Update()
    {

        foreach (Transform back in background)
        {
            if (back.transform.position.y > height * background.Length / 6)
            {
                back.transform.Translate(new Vector2(0, height * (background.Length / 6) * -2));

                if (CompareTag("Dead"))
                {
                    float newPositionX = back.transform.localPosition.x;

                    float newPositionY = back.transform.localPosition.y;

                    newPositionX = Random.Range(randomPositionX.x, randomPositionX.y);
                    newPositionY = Random.Range(randomPositionY.x, randomPositionY.y);

                    back.transform.localPosition = new Vector2(newPositionX, newPositionX);

                    back.transform.Translate(new Vector2(0, height * (background.Length / 2) * -0.5f));
                }

                if (CompareTag("Inicio") && back.transform.position.y > height * background.Length)
                {
                    Destroy(cut);
                }
            }

            back.Translate(velY * Time.deltaTime);
        }
    }

    private void Aumento()
    {

        if (velY.y <= limiteVelY.y)
            velY += new Vector2(0, 2) * 0.2f;
        else velY = limiteVelY;


    }
}
