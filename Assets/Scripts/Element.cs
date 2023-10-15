using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Element : MonoBehaviour
{
    [SerializeField] string tag;
    [SerializeField] UnityEvent enter;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            enter?.Invoke();
        }
    }
}
