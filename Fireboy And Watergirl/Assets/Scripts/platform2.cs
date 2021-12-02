using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform2 : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

  public GameObject lever;
    public float limit=10f;
    public float speed = 2f;
    public float position=0f;
    
    
    private void Update()
    {
        if (lever.transform.rotation.z <= -0.3)
        {
            if (position < limit) 
            {
                float thf = speed * Time.deltaTime;
                position += thf;
                GetComponent<Transform>().SetPositionAndRotation(new Vector2(transform.position.x, transform.position.y - thf), transform.rotation);
            }
        }
        else 
        {
            if (position > 0)
            {
                float thf = speed * Time.deltaTime;
                position -= thf;
                GetComponent<Transform>().SetPositionAndRotation(new Vector2(transform.position.x, transform.position.y + thf), transform.rotation);
            }
        }
    }
    

}
