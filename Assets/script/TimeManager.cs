using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    public Text timeText;
    public float totalTime = 10.0f; // Thời gian chơi tổng cộng
    private float currentTime = 0;
    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            currentTime += Time.deltaTime;
            UpdateTimeDisplay();

            if (currentTime >= totalTime)
            {
                GameOver();
            }
        }
    }

    void UpdateTimeDisplay()
    {
        float remainingTime = totalTime - currentTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60F);
        int seconds = Mathf.FloorToInt(remainingTime - minutes * 60);
        string timeString = string.Format("{0:0}:{1:00}", minutes, seconds);
        timeText.text = "Time: " + timeString;
    }

    void GameOver()
    {
        isGameOver = true;

        // Hiển thị màn hình Game Over, có thể thực hiện thông qua việc kích hoạt một panel Game Over trong Canvas
        Debug.Log("Game Over!");
    }
}                                                           