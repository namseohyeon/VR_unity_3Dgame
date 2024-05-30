using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private Player4 gameController;
    public Text WinText;
    public Text LoseText;


    void Start()
    {
        gameController = FindObjectOfType<Player4>();
        WinText.gameObject.SetActive(false);
        LoseText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (gameController.PinkDonutCount >= gameController.requiredPinkDonuts && gameController.BrownDonutCount >= gameController.requiredBrownDonuts)
            {
                //Debug.Log(gameController.PinkDonutCount + gameController.requiredPinkDonuts + gameController.BrownDonutCount + gameController.requiredBrownDonuts);
                WinText.text = "You Win!"+ "\n" + "NEXT";
                WinText.gameObject.SetActive(true);

            }
            else{
                //Debug.Log("gameController.PinkDonutCount"+ gameController.PinkDonutCount + "gameController.requiredPinkDonuts" +  gameController.requiredPinkDonuts + "gameController.requiredPinkDonuts"+ gameController.BrownDonutCount +"gameController.requiredBrownDonuts" +gameController.requiredBrownDonuts);
                LoseText.text = "You Lose!" +"\n" +"REPLAY";
                LoseText.gameObject.SetActive(true);
            }
            Time.timeScale = 0; // 게임 멈추기
        }
    }

}
