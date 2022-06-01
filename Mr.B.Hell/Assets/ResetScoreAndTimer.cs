using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScoreAndTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ResetScores", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ResetScores()
    {
        //print(FindObjectsOfType<Timer>().Length);

        FindObjectOfType<Timer>().ResetTimer();
        FindObjectOfType<GameSession>().ResetScore();
    }
}
