using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedown : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 2f;
    public float position=0f;
    public float endpos =0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void move(){
        float thf = speed * Time.deltaTime;
        position += thf;
        GetComponent<Transform>().SetPositionAndRotation(new Vector2(transform.position.x, transform.position.y - thf), transform.rotation);
    }
}
