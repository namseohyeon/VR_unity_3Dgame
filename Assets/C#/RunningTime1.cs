using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningTime1 : MonoBehaviour
{
    public float timeLimit = 35f;
    public Text timerText;
    public Text WinText;
    public Text LoseText;

    private float timeLeft;
    private bool gameEnded = false;

    void Start()
    {
        timeLeft = timeLimit;
        //resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!gameEnded)
        {  
            timeLeft = timeLeft-Time.deltaTime;
            Debug.Log(timeLeft);
            if (timeLeft <= 30){
            timerText.text = "Time Left: " + timeLeft.ToString();}

            if (timeLeft <= 0)
            {
                timerText.text = "Time Left: 0";
                EndGame();
            }
        }
    }

    public void EndGame()
    {
        LoseText.text = "You Lose!"+ "\n" + "REPLAY";
        LoseText.gameObject.SetActive(true);
    // if (success)
    //     {
    //         WinText.text = "You Win!" + "\n" + "FINISH";
    //         WinText.gameObject.SetActive(true);
    //     }
    //     else
    //     {
    //         LoseText.text = "You Lose!"+ "\n" + "REPLAY";
    //         LoseText.gameObject.SetActive(true);
    //     }
        
       
    //}
     Time.timeScale = 0;
}
}
