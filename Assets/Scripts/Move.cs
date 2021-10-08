using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public bool dead;
    [SerializeField] private Animator animator;
    private AudioSource morteSom;

    void Start()
    {
        morteSom = GetComponent<AudioSource>();
        DATA.Cut = 1;
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
                transform.position += (Vector3)t.deltaPosition / 250;
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
        morteSom.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            Death();
        }
    }
}
