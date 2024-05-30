using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class first : MonoBehaviour
{
    public void SceneChange(){
        SceneManager.LoadScene("New Scene small");
    }
}
