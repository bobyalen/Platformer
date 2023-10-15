using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    Animator animator;
    [SerializeField] UnityEvent enter;
    [SerializeField] UnityEvent exit;
    [SerializeField] private AudioSource flip;

    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enter?.Invoke();
            flip.Play();
            animator.SetTrigger("Flip");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Flip");
            exit?.Invoke();
        }
    }
}