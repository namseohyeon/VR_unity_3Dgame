using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public Player4 player;
    public Text text;
    public Camera mainCamera; // 주 카메라
    public Camera secondaryCamera;
    // Start is called before the first frame update

    public void OnClick(){
        player.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(true);
        secondaryCamera.gameObject.SetActive(false);
        text.text = " ";
    }
}
