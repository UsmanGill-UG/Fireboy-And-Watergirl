using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 Pos;
    public Rigidbody2D rb;
    public float speed = 5f;
    public float JumpForce =5f;
    public Animator animator;
    public bool IsGrounded;
    public static int score = 0 ;
    public bool whitedoor = false;

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
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "fire"){
            SceneManager.LoadScene(0);
        }
        else if(collision.tag == "blue_gem"){
            Debug.Log("Score : "+ score);
            Destroy(collision.gameObject);

            score += 1;
                       Debug.Log("Score : "+ score);
        }
        if(collision.tag == "white_door"){
            whitedoor = true;
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
