using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animation : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody;
    SpriteRenderer sprite;
    [SerializeField] private AudioSource death;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void movement()
    {
        float xSpeed = Mathf.Abs(rigidBody.velocity.x);
        animator.SetFloat("xspeed", xSpeed);
        float ySpeed = rigidBody.velocity.y;
        animator.SetFloat("yspeed", ySpeed);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Die();
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        Restart();
    }

    public void Die()
    {
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        death.Play();
        animator.SetTrigger("die");
        StartCoroutine(delay());
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
