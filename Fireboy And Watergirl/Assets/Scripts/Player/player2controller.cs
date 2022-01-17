using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player2controller : MonoBehaviour
{
 // Start is called before the first frame update
    public Vector2 Pos;
    public Rigidbody2D rb;
    public float speed ;
    public float JumpForce =5f;
    public Animator animator;
    public bool IsGrounded;
    public bool jg;
    public bool reddoor= false;
        public bool pkopen= false;
    public bool pk= false;
    public static int score=0;
    public GameObject score_counter;
    public GameObject pc;
    public bool ag;
    public float agtimer;
        public int lives;

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
        if(collision.tag == "red_door"){
            reddoor = true;
        }
        if(collision.tag == "water" || collision.tag == "spikes"){
            SceneManager.LoadScene(1);
        }
        if(collision.tag == "purple_key" ){
            Destroy(collision.gameObject);
            pk = true;
        }
        if(collision.tag == "purplechest" && pk == true){
            pc.GetComponent<purplechest_code>().animchest();
            pkopen = true;
        }
        if(collision.tag == "coin"){
            score_counter.GetComponent<scoredisplay>().update_score();
            Debug.Log("Score : "+ score);
            Destroy(collision.gameObject);
            score += 1;
            Debug.Log("Score : "+ score);
        }
        if(collision.tag == "ag"){
              ag = true;
            Destroy(collision.gameObject);
        }

    }


    // Update is called once per frame
    void Update()
    {
       // Pos = transform.position;
        if(Input.GetKeyDown(KeyCode.W) &&  (IsGrounded == true || jg == true)){
            IsGrounded = false;
           // rb.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            animator.SetTrigger("jump2");
        }
        //Pos = transform.position;

        if(ag == true)
        {
                if(Input.GetKey(KeyCode.A)){
            rb.gravityScale *=-1;    
            transform.eulerAngles = new Vector3(0,180,0);
            rb.velocity = new Vector2(-speed, rb.velocity.y); 
            animator.SetTrigger("running2");
            }
            if(Input.GetKey(KeyCode.D)){
            rb.gravityScale *=-1;
            transform.eulerAngles = new Vector3(0,0,0);
            rb.velocity = new Vector2(speed, rb.velocity.y); 
            animator.SetTrigger("running2");
            }
            else{
                rb.gravityScale *=-1;    
                 animator.SetTrigger("idle2");
            }
            agtimer += Time.deltaTime;
            if(agtimer >= 3){
                ag = false;
                agtimer = 0;
                rb.gravityScale = 30;    
            }
        
        }
        else{
                  if(Input.GetKey(KeyCode.A)){
           // Pos.x -= speed*Time.deltaTime;
            transform.eulerAngles = new Vector3(0,180,0);
            rb.velocity = new Vector2(-speed, rb.velocity.y); 
           // rb.MovePosition(Pos);
            animator.SetTrigger("running2");
        }
        else if(Input.GetKey(KeyCode.D)){
            //Pos.x += speed*Time.deltaTime;
            transform.eulerAngles = new Vector3(0,0,0);
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //rb.MovePosition(Pos);
            animator.SetTrigger("running2");
        }
        else{
              animator.SetTrigger("idle2");
        }
        }
      //  rb.MovePosition(Pos);
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
*/