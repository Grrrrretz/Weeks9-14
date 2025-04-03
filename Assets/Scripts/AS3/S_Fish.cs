using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Fish : MonoBehaviour
{
    // Start is called before the first frame update

    public int FishType;
    public GameObject Fish;

    public SpriteRenderer spriteRenderer;

    public AnimationCurve AnimationCurve;
    bool GetFish = false;
    public float t = 0f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetMouseButtonDown(0) && spriteRenderer.bounds.Contains(mousepos))
        {
            Destroy(Fish,1);
            GetFish = true;
        }
        else
        {
            Destroy(Fish, 5);
        }
        if (GetFish == true)//Play the animation
        {
            Vector3 vector3 = transform.localScale;
            t += Time.deltaTime;
            transform.localScale = vector3 * AnimationCurve.Evaluate(t);
        }
    }
}
