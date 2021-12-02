using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player1.GetComponent<PlayerController>().whitedoor &&  player2.GetComponent<player2controller>().reddoor){
            SceneManager.LoadScene(0);
        }
        
    }
}
