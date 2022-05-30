using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private static Score thisInstance;
    [SerializeField] TextMeshProUGUI scoreText;

    GameSession gameSession;

    bool playing = true;
    string finishTime = "";

    void Awake()
    {
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

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
