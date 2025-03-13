using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_changeingscrip : MonoBehaviour
{
    public Image image;
    public Sprite food;
    public Sprite food2;
    public GameObject cafe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeIMG()
    {
        image.sprite = food2;
    }
    public void changeback()
    {
        image.sprite = food;
    }
    public void spawnPrefab()
    {

        Instantiate(cafe, Random.RandomRange(1, 10) * Vector3.one, Quaternion.identity);
    }
}
