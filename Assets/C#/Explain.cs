using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Explain : MonoBehaviour
{
    public GameObject player; // 플레이어 오브젝트
    //public Text startText; // 시작 텍스트 UI
    public float movingDelay; // 시작 전 대기 시간
    public float startDelay; // 시작 전 대기 시간
   public GameObject buttonObject;

    void Start()
    {
        // 플레이어와 텍스트를 설정
        // if (player != null)
        //     player.SetActive(false);
       // Time.timeScale = 0;

        // if (startText != null)
        //     startText.enabled = true; // 텍스트 활성화

        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        
        yield return new WaitForSeconds(movingDelay); // 대기 시간
        // //Time.timeScale = 1;
        if (buttonObject != null){
             buttonObject.SetActive(true);  // 텍스트 비활성화
            yield return new WaitForSeconds(startDelay);
            buttonObject.SetActive(false);
        // if (player != null)
        //     player.SetActive(true); // 플레이어 활성화
        }

        
    }
}

