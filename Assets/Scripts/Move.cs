using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private bool dead;

    // Update is called once per frame
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

    public bool Death()
    {
        BackgroundMove[] background = FindObjectsOfType<BackgroundMove>();

        foreach (BackgroundMove backg in background)
        {
            backg.enabled = false;
        }

        dead = true;

        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            Death();
        }
    }
}
