using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    public Text scoreText;
    private int score = 0;
    private string format = "Score: {0}";

    public int Score
    {
        get { return score; }
        set { 
            score = value;
            scoreText.text = string.Format(format, value);
        }
    }

    void Start()
    {
        Score = 0;
    }

    public void increaseScore()
    {
        Score += 1;
    }
}
