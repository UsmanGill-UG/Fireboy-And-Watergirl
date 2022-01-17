using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lever_ball : MonoBehaviour
{

    public GameObject plat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector3 scale = transform.localScale;
      if(collision.transform.tag == "ball"){
          plat.GetComponent<movedown>().move();
          Debug.Log("HERE");
          transform.Rotate(0,180,0);
        }
    }
}
