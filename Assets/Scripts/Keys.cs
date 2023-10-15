using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Keys : MonoBehaviour
{
    private int found;
    [SerializeField] Text keyCounter;
    [SerializeField] UnityEvent check;
    void start()
    {
        found = 0;
    }

    // Update is called once per frame
    public void keycounter()
    {
        found++;
        keyCounter.text = "Keys: " + found;
        if (found == 3)
        {
            check?.Invoke();
        }
    }

    

}
