using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class housePlayer : MonoBehaviour
{
    public float speed;
    private bool moving = false;
    private bool reachedTarget = false;
    public Camera mainCamera; // 주 카메라
    public Camera secondaryCamera; // 보조 카메라
    private float delay = 3f;
    private float timer = 0;
    public Text resultText;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       //rb = GetComponent<Rigidbody>(); 
       ActivateCamera(mainCamera); 
       anim = GetComponentInChildren<Animator>();
       Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (!reachedTarget){
            FirstMove();
            StartCoroutine(WaitAndPrint());
        }
        else{
            timer += Time.deltaTime;
            if(timer >= delay){
                ActivateCamera(secondaryCamera);
                HandleMove();
            }
            
        }
    }

    void FirstMove(){
        Vector3 targetPosition = new Vector3(1, 0, -10);
        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance > 0.1f){
            if (!moving)
            {
                anim.SetBool("isWalk", true);
                moving = true;
                Debug.Log("1");
            }
            Debug.Log("2");
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * 4 * Time.deltaTime;
        
        }
        else if (moving) // 목표 지점에 도달했다면
        {
            Debug.Log(transform.position);
            // 이동 애니메이션 비활성화
            anim.SetBool("isWalk", false);
            moving = false;
            reachedTarget = true;
        }
        
        //anim.SetBool("isWalk", movement != Vector3.zero );
    }

    void HandleMove(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Debug.Log("Horizontal: " + moveHorizontal + ", Vertical: " + moveVertical);
        //wDown = Input.GetButtom("walk");

        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical).normalized;

        transform.position += movement * speed * Time.deltaTime ;

        anim.SetBool("isWalk", movement != Vector3.zero );
        //anim.SetBool("isWalk", wDown);
        transform.LookAt(transform.position + movement);

    }

    private void ActivateCamera(Camera cameraToActivate)
    {
        // 모든 카메라 비활성화
        mainCamera.gameObject.SetActive(false);
        secondaryCamera.gameObject.SetActive(false);

        // 지정된 카메라 활성화
        cameraToActivate.gameObject.SetActive(true);
    }

        IEnumerator WaitAndPrint()
    {
        // 5초 동안 대기
        yield return new WaitForSeconds(5);
        // 5초 후 로직 실행
        Debug.Log("5 seconds have passed!");
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("ghost")){
            Debug.Log("dddd");
            resultText.text = "You Lose!" +"\n" +"REPLAY";
            resultText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

}