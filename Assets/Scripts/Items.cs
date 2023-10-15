using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Items : MonoBehaviour
{
    [SerializeField] UnityEvent enter;
    [SerializeField] private AudioSource key;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            key.Play();
            enter?.Invoke();
        }
    }

}
