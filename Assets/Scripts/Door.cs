using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    Animator animator;
    bool keysFound = false;
    [SerializeField] private AudioSource doorOpen;
    [SerializeField] private AudioSource finish;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void open()
    {
        animator.SetTrigger("Open");
        keysFound = true;
        doorOpen.Play();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {;
        Debug.Log(keysFound);
        if (collision.gameObject.CompareTag("Player") && keysFound)
        {
            finish.Play();
            End();
        }
    }

    private void End()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("here");
    }
}
