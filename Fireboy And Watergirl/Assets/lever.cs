using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    // Start is called before the first frame update
    public bool switchon = false;
    public Animator animator;
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "players"){
            animator.SetTrigger("left");
            switchon = true;
        }


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
