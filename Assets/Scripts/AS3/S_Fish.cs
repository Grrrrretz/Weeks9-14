using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_Fish : MonoBehaviour
{
    // Start is called before the first frame update

    public int FishType;
    public GameObject Fish;

    public SpriteRenderer spriteRenderer;

    public AnimationCurve AnimationCurve;
    bool GetFish = false;
    public float t = 0f;
    //Set up the listeners that will be used
    public UnityEvent smallfish;

    public UnityEvent bigfish;

    public UnityEvent badfish;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetMouseButtonDown(0) && spriteRenderer.bounds.Contains(mousepos))//When the mouse is clicked and overlaps with the sprite, the corresponding listener will be triggered based on the type of fish, the animation will play, and the sprite will be destroyed.
        {
            if(FishType == 0)
            {
                smallfish.Invoke();
            }
            else if (FishType == 1)
            {
                bigfish.Invoke();
            }
            else if (FishType == 2)
            {
                badfish.Invoke();
            }
            Destroy(Fish,1);
            GetFish = true;
        }
        else
        {
            Destroy(Fish, 5);//If the fish is not clicked within 5 seconds, it will automatically disappear.
        }
        if (GetFish == true)//Play the animation
        {
            Vector3 vector3 = transform.localScale;
            t += Time.deltaTime;
            transform.localScale = vector3 * AnimationCurve.Evaluate(t);
        }
    }
}
