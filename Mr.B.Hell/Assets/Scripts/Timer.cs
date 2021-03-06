using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private static Timer thisInstance;
    [SerializeField] TextMeshProUGUI timerText;

    Level level;

    bool playing = true;
    float theTime = 0 , speed = 1;
    string finishTime = "";
    void Awake()
    {
        level = FindObjectOfType<Level>();

        if (thisInstance == null)
        {
            thisInstance = this;
            DontDestroyOnLoad(thisInstance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            theTime += Time.deltaTime * speed;
            // string hours = Mathf.Floor((theTime % 216000) / 3600).ToString("00");
            string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
            string seconds = (theTime % 60).ToString("00");
            string milliseconds = (theTime * 1000 % 1000).ToString("00");
            timerText.text = minutes + ":" + seconds + ":" + milliseconds;
        }
    }
    public void Finish()
    {
        print("calling finish");
        playing = false;
        finishTime = timerText.text;
    }

    public void ResetTimer()
    {
        playing = true;
        theTime = 0;
        finishTime = "";
    }

    public string GetFinishTime() { return finishTime; }

}
