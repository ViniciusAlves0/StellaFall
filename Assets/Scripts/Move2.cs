using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public float speed;
Rigidbody2D rigidbody2d;

void Start()
{
    rigidbody2d = GetComponent<Rigidbody2D>();
}
public class Move : MonoBehaviour
{
    public bool dead;
    [SerializeField] private Animator animator;

    void Start()
    {
        dead = false;
        animator.SetBool("Morreu", false);
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("GameO") && dead)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (dead)
            return;

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Moved)
            {
                rigidbody2d.velocity = new Vector2(Mathf.Sign(t.deltaPosition) * speed, 0f);
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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
        animator.SetBool("Morreu", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            Death();
        }
    }
}
