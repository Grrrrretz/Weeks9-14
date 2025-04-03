using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GoodTime : MonoBehaviour
{
    // Start is called before the first frame update
    int fishumber = 0;
    float Timer = 0;
    bool GoodTime = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }else if( Timer <= 0)
        {
            fishumber = 0;
        }
    }
    public void Getfish()
    {
        fishumber += 1;

        Timer = 2;


    }
    IEnumerator GoodTimeactive()
    {
        GoodTime = true;
        yield return new WaitForSeconds(5);
        GoodTime = false;
        fishumber = 0;
    }
}
