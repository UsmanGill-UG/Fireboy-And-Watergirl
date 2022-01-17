using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 Pos;
    public Rigidbody2D rb;
    public float speed;
    public float JumpForce =5f;
    public Animator animator;
    public bool IsGrounded;
    public bool jg;
    public static int score = 0 ;
    public bool whitedoor = false;
    public bool gk = false;
    public GameObject score_counter;
    public GameObject gc;
    public bool gcopen = false;
    public bool hj = false;
    public float hjtimer = 0;
    public bool hs = false;
    public float hstimer = 0;
    public bool ag = false;
    public float agtimer = 0;
    public GameObject timeobj;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.transform.tag == "jumpground"){
            jg = true;
        }
        else{
          jg = false;
         }
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
        if(collision.tag == "fire" || collision.tag == "spikes" ){
            SceneManager.LoadScene(1);
        }
        if(collision.tag == "coin"){
            score_counter.GetComponent<scoredisplay>().update_score();
            Debug.Log("Score : "+ score);
            Destroy(collision.gameObject);
            score += 1;
                       Debug.Log("Score : "+ score);
        }
        if(collision.tag == "white_door"){
            whitedoor = true;
        }
        if(collision.tag == "gold_key"){
            Destroy(collision.gameObject);
            gk = true;
        }
        if(collision.tag == "goldchest" && gk == true){
            gc.GetComponent<goldchest_code>().animchest();
            gcopen = true;
        }
        if(collision.tag == "highjump"){
            Destroy(collision.gameObject);
            hj = true;
        }
        if(collision.tag == "speed"){
            Destroy(collision.gameObject);
            hs = true;
        }
        if(collision.tag == "time"){
            Destroy(collision.gameObject);
            timeobj.GetComponent<patrol>().setmovement();
        }
    }
    // Update is called once per frame
    void Update()
    {
      // Pos = transform.position;
  
        if(hj == true){
            hjtimer += Time.deltaTime;
            if(hjtimer >= 3){
                hj = false;
                hjtimer = 0;
            }
            if(Input.GetKeyDown(KeyCode.UpArrow) &&  (IsGrounded == true || jg == true)){
            IsGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce * 2);
            animator.SetTrigger("jump");
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) &&  (IsGrounded == true || jg == true)){
            IsGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            animator.SetTrigger("jump");
            }
        // high speed
        if(hs == true)
        {
            hstimer += Time.deltaTime;
            if(hstimer >= 3){
                hs = false;
                hstimer = 0;
            }
            if(Input.GetKey(KeyCode.LeftArrow)){
            transform.eulerAngles = new Vector3(0,180,0);
            rb.velocity = new Vector2(-speed*2, rb.velocity.y); 
            animator.SetTrigger("running");
            }
            if(Input.GetKey(KeyCode.RightArrow)){
            transform.eulerAngles = new Vector3(0,0,0);
            rb.velocity = new Vector2(speed*2, rb.velocity.y); 
            animator.SetTrigger("running");
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            transform.eulerAngles = new Vector3(0,180,0);
            rb.velocity = new Vector2(-speed, rb.velocity.y); 
            animator.SetTrigger("running");
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            transform.eulerAngles = new Vector3(0,0,0);
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator.SetTrigger("running");
        }
        else{
              animator.SetTrigger("idle");
        }
    }
}


/*
      if(ag == true)
        {
            agtimer += Time.deltaTime;
            if(agtimer >= 3){
                ag = false;
                agtimer = 0;
            }
            if(Input.GetKey(KeyCode.LeftArrow)){
            rb.gravityScale *=-1;    
            transform.eulerAngles = new Vector3(0,180,0);
            rb.velocity = new Vector2(-speed, rb.velocity.y); 
            animator.SetTrigger("running");
            }
            if(Input.GetKey(KeyCode.RightArrow)){
            rb.gravityScale *=-1;
            transform.eulerAngles = new Vector3(0,0,0);
            rb.velocity = new Vector2(speed, rb.velocity.y); 
            animator.SetTrigger("running");
            }
            else{
                 animator.SetTrigger("idle");
            }
        }
*/