using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CoroutineChangeSprite : MonoBehaviour
{
    public Transform TargetSprite;
    public float t;
    public AnimationCurve Curve;
    Coroutine Rotating;
    // Start is called before the first frame update
    void Start()
    {

        Rotating = StartCoroutine(ChangeSpriteRotation());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ChangeSpriteRotation()
    {
        t = 0;
        while (t < 10)
        {
            t += Time.deltaTime;
            TargetSprite.Rotate(0, 0, 10 * Curve.Evaluate(t));

            yield return null;
        }

    }
    public void stopRotating()
    {
        if (Rotating != null)
        {
            StopCoroutine(Rotating);
        }
    }
}
