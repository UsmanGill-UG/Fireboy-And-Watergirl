using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoredisplay : MonoBehaviour
{
    public TextMeshProUGUI score_text ;
    public int score ;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = "Score : "+ score.ToString();
    }

    public void update_score(){
        score++;
    }
}
