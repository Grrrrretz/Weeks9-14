using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class S_GoodTime : MonoBehaviour
{
    // Start is called before the first frame update
    public int fishumber = 0;
    public float Timer = 0;
    public bool GoodTime = false;
    public S_Score Score;
    //Set up the listeners that will be used
    public UnityEvent GoodtimeStart;
    public UnityEvent GoodtimeEnd;

    public SpriteRenderer BG;

    Coroutine active;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)//When the time is greater than 0, it starts decreasing over time to create a countdown effect.
        {
            Timer -= Time.deltaTime;
        }else if( Timer <= 0)//Reset the accumulated count when the timer ends.
        {
            fishumber = 0;
        }
        if (GoodTime == true)//Change the background color when GoodTime is triggered.
        {
            BG.color = Color.yellow;
        }
        else 
        { 
            BG.color= Color.white;
        }
    }

    public void GoodTiming()//Used to check the trigger conditions for Good Time.
    {

        fishumber++;//Each time it's triggered, the fish count increases by 1 and accumulates within a 5-second window.
        Timer = 5;

        if(GoodTime== false && fishumber >= 3)//Activate the Good Time effect when the count meets the required threshold.
        {
        active = StartCoroutine(GoodTimeactive());
        }
        else if(Timer <= 0)//Deactivate it when it ends.And also prevent accidental triggers.
        {
            StopCoroutine(active);
        }


            
    }
    IEnumerator GoodTimeactive()//Use a coroutine to activate the listener when triggered, enabling double scoring in `Score` and changing the background.
    {
        GoodTime = true;
        GoodtimeStart.Invoke();
        yield return new WaitForSeconds(5);//Reset after 5 seconds.
        Debug.Log("I on");
        GoodTime = false;
        GoodtimeEnd.Invoke();
        fishumber = 0;
    }
}
