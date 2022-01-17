using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purplechest_code : MonoBehaviour
{
    // Start is called before the first frame update
           public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void animchest(){
         animator.SetTrigger("open");
    }
    
}
