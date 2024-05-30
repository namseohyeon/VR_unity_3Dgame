using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    public float speed;
    public Camera mainCamera; // 주 카메라
    //public Camera secondaryCamera;
    


    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       //rb = GetComponent<Rigidbody>(); 
       anim = GetComponentInChildren<Animator>();
       Time.timeScale = 1;
       mainCamera = Camera.main;
       

       //timeLeft = timeLimit;
       //resultText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Debug.Log("Horizontal: " + moveHorizontal + ", Vertical: " + moveVertical);
        //wDown = Input.GetButtom("walk");

        //Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical).normalized;

        //transform.position += movement * speed * Time.deltaTime ;

        //anim.SetBool("isRun", movement != Vector3.zero );
        //anim.SetBool("isWalk", wDown);
        //transform.LookAt(transform.position + movement);

        Vector3 moveDirection = mainCamera.transform.forward * moveVertical + mainCamera.transform.right * moveHorizontal;
        moveDirection.y = 0; // Y축 움직임 제거
        moveDirection.Normalize(); // 방향 벡터 정규화

        if (moveDirection != Vector3.zero)
        {
        anim.SetBool("isRun", true);
        transform.position += moveDirection * speed * Time.deltaTime;
        //transform.LookAt(transform.position + movement);
        transform.forward = moveDirection;
        }
        else
        {
        anim.SetBool("isRun", false);
        }


    }

}