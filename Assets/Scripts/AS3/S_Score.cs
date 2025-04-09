using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class S_Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int Score = 0;
    public bool GoodTime = false;

    public TextMeshProUGUI Text;
    //Set up the listeners that will be used
    public UnityEvent TextChangeColor;

    void Start()
    {
        Text.color = Color.black;//Set the default text color to black.
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GoodTime);
        Text.text = "Score: " + Score;//Make the text display the real-time score.
        if (GoodTime == true)//Change the text color when GoodTime is triggered.
        {
            //Use adding and removing the listener as a switch to trigger the text color change, while keeping the listener system itself always active.
            TextChangeColor.AddListener(TextChange);
            TextChangeColor.Invoke();//To ensure the color isn't changed at the very beginning, activate the listener only after Good Time has started for the first time.
        }
        else
        {

           TextChangeColor.RemoveListener(TextChange);
        }
    }
    public void GetSmallFish()//Scoring and point deduction for different types of fish.
    {
        if (GoodTime == true)
        {
            Score += 2;

        }
        else
        {
            Score += 1;
        }
    }
    public void GetBigFish()
    {
        if (GoodTime == true)
        {
            Score += 6;
        }
        else
        {
            Score += 2;
        }
    }
    public void GetBadFish()
    {
        Score -= 2;
    }
    public void GoodTimeStart()//Control whether Good Time is active.
    {
        GoodTime = true;
    }
    public void GoodTimeEnd()
    {
        GoodTime = false;
        Text.color = Color.black;//Revert the color after Good Time ends.
    }
    public void TextChange()//Control the color change.
    {
        Text.color = Color.red;
    }
}
