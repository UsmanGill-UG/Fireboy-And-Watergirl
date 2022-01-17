using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{

    public bool movement = true;
    [Header ("Petrol Points")]
    [SerializeField]
    private Transform LeftEdge;
    [SerializeField]
    private Transform RightEdge;


    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingleft;

    [Header("idle Behaviour")]
    [SerializeField]
    private float Idle_Duration;
    private float idletimer;

    [Header("Enemy Animator")]
    [SerializeField]
    private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable() // called when enemy patrol is disabled 
    {
        anim.SetBool("moving", false);
    }

    private void Update()
    {
      if(movement != false){
            if(movingleft)
            {
                if(enemy.position.x>=LeftEdge.position.x)// keep moving left
                    MoveinDirection(-1);
                else
                {
                    ChangeDirection();
                }
            }
            else
            {
                if(enemy.position.x<=RightEdge.position.x) // keep moving right
                    MoveinDirection(1);
                else
                {
                    ChangeDirection();
                }
            }
      }
            
    }
    public void setmovement(){
        movement = false;
    }
    private void ChangeDirection()
    {
        anim.SetBool("moving", false);

        idletimer += Time.deltaTime;

        if(idletimer> Idle_Duration) //change direction
            movingleft = !movingleft; // negation

    }
    private void MoveinDirection( int _Direction)
    {
        idletimer = 0; // enemy moving in certain direction
        anim.SetBool("moving", true);
        // make enemy face in the right direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x)* _Direction, 
            initScale.y, initScale.z);

        // make it move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _Direction * speed,enemy.position.y,enemy.position.z);

    }
}
