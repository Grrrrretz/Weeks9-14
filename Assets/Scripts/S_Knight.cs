using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class S_Knight : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    AudioSource audio;
    public float speed = 2;
    public float hight = 1;
    public bool canrun = true;
    public AudioClip[] soundlist;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        sr.flipX = direction < 0;

        animator.SetFloat("Movement", Mathf.Abs(direction));

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            canrun = false;
        }

        if(canrun == true)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jump",true);
            canrun = false;
            transform.position += transform.up * hight * Time.deltaTime*15;
        }
        if (transform.position.y > 1.5)
        {
            transform.position -= transform.up * hight * Time.deltaTime * 15;
        }
        else if (transform.position.y <= 0)
        {
            Vector3 pos = new Vector3(transform.position.x, 0, 0);
            transform.position = pos;
        }
    }

    public void AttackHasFinish()
    {
        Debug.Log("attack is finished");
        canrun = true;
    }
    public void playsound()
    {
        int number = Random.Range(0, soundlist.Length);
        audio.PlayOneShot(soundlist[number]);
    }
}
