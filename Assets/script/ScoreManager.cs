using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
            }
            return instance;
        }
    }
    private int score = 0;
    public void IncreaseScore(int value)
    {
        score += value;
        Debug.Log("Score Increased! New Score: " + score);
    }
}

