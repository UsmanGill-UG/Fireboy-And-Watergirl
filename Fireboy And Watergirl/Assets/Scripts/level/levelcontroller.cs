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
        // for level 1
        if(player1.GetComponent<PlayerController>().whitedoor &&  player2.GetComponent<player2controller>().reddoor){
            SceneManager.LoadScene(1);
        }
        // for level 2
        if(player1.GetComponent<PlayerController>().gcopen &&  player2.GetComponent<player2controller>().pkopen){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
