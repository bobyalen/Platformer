using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject[] waypoints;
    [SerializeField] float speed;
    int current = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        checkTrue();
    }
    public void startMovement()
    {
        animator.SetTrigger("Flipped");
    }

    void checkTrue()
    {
        if (animator.GetBool("Flipped") == true)
        {
            move();
        }
    }

    private void move()
    {
        if (Vector2.Distance(waypoints[current].transform.position, transform.position) < 0.05f)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
