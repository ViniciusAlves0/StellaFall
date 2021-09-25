using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool dead = false;

    void Update()
    {
        if (dead)
            return;

        if(Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if(t.phase == TouchPhase.Moved)
            {
                transform.position += (Vector3)t.deltaPosition/250;
            }
        }
    }

    private void Death()
    {
        BackgroundMove[] background = FindObjectsOfType<BackgroundMove>();

        foreach (BackgroundMove backg in background)
        {
            backg.enabled = false;
        }

        dead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            Death();
        }
    }
}
