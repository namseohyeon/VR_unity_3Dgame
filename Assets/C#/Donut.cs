using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("player")){
            other.GetComponent<Player3>().IncreaseDonutCount();
            gameObject.SetActive(false);
        }
    }

}
