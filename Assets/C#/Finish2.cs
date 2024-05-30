using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish2 : MonoBehaviour
{
    //private Player4 gameController;
    public Text WinText;


    void Start()
    {
        //gameController = FindObjectOfType<Player4>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {

            WinText.text = "Stage Clear" + "\n" + "NEXT";
            WinText.gameObject.SetActive(true);


            Time.timeScale = 0; // 게임 멈추기
        }
    }


}
