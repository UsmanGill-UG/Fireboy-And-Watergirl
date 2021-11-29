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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Pos = transform.position;
        if(Input.GetKey(KeyCode.LeftArrow)){
            Pos.x -= speed*Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            Pos.x += speed*Time.deltaTime;
        }
        rb.MovePosition(Pos);
    }
}
