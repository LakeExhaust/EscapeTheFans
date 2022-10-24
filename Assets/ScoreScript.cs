using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    Text score;
    GameManger gameManger;
    int scoreValue = 0;
    void Start()
    {
        gameManger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();
        
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue = gameManger.getCounter();
        score.text = " Score: " + gameManger.getCounter();
        if (scoreValue >= 5)
        {
            Debug.Log("We're here-score");
            gameManger.increaseSpeed();
        }
    }
}
