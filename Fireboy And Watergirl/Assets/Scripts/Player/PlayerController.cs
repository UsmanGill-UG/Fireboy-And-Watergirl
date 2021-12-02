using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 Pos;
    public Rigidbody2D rb;
    public float speed = 5f;
    public float JumpForce =5f;
    public Animator animator;
    public bool IsGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ground"){
            IsGrounded = true;
        }
        else{
            IsGrounded=false;
        }
        
        if(collision.transform.tag == "player"){
            IsGrounded = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Pos = transform.position;
        if(Input.GetKey(KeyCode.LeftArrow)){
            Pos.x -= speed*Time.deltaTime;
            transform.eulerAngles = new Vector3(0,180,0);
            rb.MovePosition(Pos);
            animator.SetTrigger("running");
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            Pos.x += speed*Time.deltaTime;
            transform.eulerAngles = new Vector3(0,0,0);
            rb.MovePosition(Pos);
            animator.SetTrigger("running");
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) &&  IsGrounded==true){
            IsGrounded = false;
            rb.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
        else{
              animator.SetTrigger("idle");
        }
      //  rb.MovePosition(Pos);
    }
}
