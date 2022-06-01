using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScoreAndTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("RESET");
        FindObjectOfType<Timer>().ResetTimer();
        FindObjectOfType<GameSession>().ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
