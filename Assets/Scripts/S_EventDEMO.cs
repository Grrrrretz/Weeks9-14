using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_EventDEMO : MonoBehaviour
{
    public RectTransform bananna;
    public UnityEvent OnTimerHasFinished;
    public float timerLength = 3;
    public float t;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > timerLength)
        {
            t = 0;
            OnTimerHasFinished.Invoke();
        }
    }

    public void MousejustEnterImage()
    {
        Debug.Log("Mouse just entered me");
        bananna.localScale = Vector3.one * 1.2f;
    }
    public void MousejustExitImage()
    {
        Debug.Log("Mouse just Left me");
        bananna.localScale = Vector3.one;
    }
}
