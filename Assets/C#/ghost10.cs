using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost10 : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 startPosition = new Vector3(12, 1,10);
    private float delay = 10f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
       transform.position = startPosition;
    }

    // Update is called once per frame
        void Update()
        {   
            
            timer += Time.deltaTime; // 프레임마다 경과 시간을 더함
            if (timer >= delay) // 5초가 경과했는지 확인
            {
                
                transform.Translate(Vector3.forward * speed * Time.deltaTime); // z축 방향으로 이동
                if (transform.position.z < -15) // 일정 지점에 도달하면
                {
                    transform.position = new Vector3(12, 1,5); // 위치 재설정
                }
            }
        }
}
