using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private float attackcooldown;
    
    [SerializeField]
    private float range;

    [SerializeField]
    private float ColliderDistance;

    [SerializeField]
    private int damage;



    [SerializeField]
    private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask playerlayer;

    private float cooldowntimer =Mathf.Infinity;


    private Animator anim;

    private patrol enemyPetrol;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPetrol = GetComponentInParent<patrol>();
    }
    private void Update()
    {
        cooldowntimer += Time.deltaTime;
        
        //Attack only when player in sight
        if(PlayerInsight())
        {
            // attack on user
            if (cooldowntimer >= attackcooldown)
            {
                cooldowntimer = 0;
                anim.SetTrigger("melee");
            }

        }

        if (enemyPetrol != null)
            enemyPetrol.enabled = !PlayerInsight(); // enemy patrol is enable when player is not in sight and disabled when player is in sight
        
    }

    private bool PlayerInsight()
    {
        // using Raycasting
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center +transform.right*range * transform.localScale.x *ColliderDistance,
            new Vector3(boxCollider.bounds.size.x*range,boxCollider.bounds.size.y,boxCollider.bounds.size.z),0,
            Vector2.left,0,playerlayer); // 0 is the angle, last one is direction


        return hit.collider!=null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * ColliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void DamagePlayer()
    {
        if(PlayerInsight())
        {
            // give damage to the player health
        }
    }
}
