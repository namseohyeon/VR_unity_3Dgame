using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningTime : MonoBehaviour
{
    public float timeLimit = 30f;
    public Text timerText;
    public Text resultText;

    private float timeLeft;
    private bool gameEnded = false;

    void Start()
    {
        timeLeft = timeLimit;
        resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!gameEnded)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time Left: " + timeLeft.ToString("F2");

            if (timeLeft <= 0)
            {
                EndGame(false);
            }
        }
    }

    public void EndGame(bool success)
    {
        gameEnded = true;
        resultText.text = success ? "You Win!" : "You Lose!";
        resultText.gameObject.SetActive(true);
        Time.timeScale = 0; // 게임 멈추기
    }

    public void CheckEndCondition()
    {
        Player3 player = FindObjectOfType<Player3>();
        if (player.donutCount >= player.requiredDonuts)
        {
            EndGame(true);
        }
        else
        {
            EndGame(false);
        }
    }
}
