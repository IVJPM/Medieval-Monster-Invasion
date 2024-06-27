using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public static int scoreCount;
    private int displayScoreCount;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;
        displayScoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreCount != displayScoreCount)
        {
            displayScoreCount = scoreCount;
            scoreText.text = displayScoreCount.ToString();
        }
    }
}
