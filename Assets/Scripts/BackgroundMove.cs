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

    public Vector2 limiteVelY;
    [SerializeField] private GameObject cut;

    private void Start()
    {
        limiteVelY = new Vector2(0, 35);

        InvokeRepeating("Aumento", 5f, 15f);
    }

    void Update()
    {

        foreach (Transform back in background)
        {
            if (back.transform.position.y > height * background.Length / 6)
            {
                back.transform.Translate(new Vector2(0, height * (background.Length / 6) * -2));

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
            velY += new Vector2(0, 2) * 0.3f;
        else velY = limiteVelY;
    }
}
