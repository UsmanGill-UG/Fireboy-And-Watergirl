using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerfollower : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
    
        // float player1x = player1.transform.position.x;
        // float player2x = player2.transform.position.x;
        // float newcamx =  (player1x + player2x)/2;
         // GetComponent<Transform>().SetPositionAndRotation(new Vector3(newcamx,transform.position.y,transform.position.z),transform.rotation);

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ){
            GetComponent<Transform>().SetPositionAndRotation(new Vector3(player2.transform.position.x, player2.transform.position.y, -10), transform.rotation);
        }
        else if(Input.GetKey(KeyCode.RightArrow) ||Input.GetKey(KeyCode.LeftArrow) ||Input.GetKey(KeyCode.UpArrow)){
            GetComponent<Transform>().SetPositionAndRotation(new Vector3(player1.transform.position.x, player1.transform.position.y, -10), transform.rotation);
        }
    }
}
