using UnityEngine;
using UnityEngine.UI;

public class Player4 : MonoBehaviour
{
    public float speed;
    //private Rigidbody rb;
    public int PinkDonutCount = 0;
    public int BrownDonutCount = 0;
    public int requiredPinkDonuts = 5;
    public int requiredBrownDonuts = 5;
    Animator anim;
    //public Text next;
    public Text countText;
    Vector3 targetPosition = new Vector3(17, 0, 9);
    public Camera mainCamera; // 주 카메라
    public Camera secondaryCamera;

    
    //private Animator animator;
    
    void Start()
    {
       Time.timeScale = 1; 
       //rb = GetComponent<Rigidbody>(); 
       anim = GetComponentInChildren<Animator>();
       //intro();
       //next.text = "";
       SetCountText();
       
       //mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    
    {
        anim = GetComponent<Animator>();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //wDown = Input.GetButtom("walk");

        //Vector3 movement = new Vector3(-moveHorizontal,0.0f,-moveVertical).normalized;
        Vector3 moveDirection = mainCamera.transform.forward * moveVertical + mainCamera.transform.right * moveHorizontal;
        moveDirection.y = 0; // Y축 움직임 제거
        moveDirection.Normalize(); // 방향 벡터 정규화

        if (moveDirection != Vector3.zero)
        {
        anim.SetBool("isWalk", true);
        transform.position += moveDirection * speed * Time.deltaTime;
        //transform.LookAt(transform.position + movement);
        transform.forward = moveDirection;
        }
        else
        {
        anim.SetBool("isWalk", false);
        }
    
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Pink")){
            PinkDonutCount = PinkDonutCount + 1;
            other.gameObject.SetActive(false);
            SetCountText();
            
        }
        else if (other.gameObject.CompareTag("Brown")){
            BrownDonutCount = BrownDonutCount + 1;
            other.gameObject.SetActive(false);
            SetCountText();
        }
        if(other.gameObject.CompareTag("ground")){
            anim.SetTrigger("fall");
            mainCamera.gameObject.SetActive(true);
            secondaryCamera.gameObject.SetActive(false);

        }
            // 원하는 애니메이션을 재생
         
            //block();
            

        //anim.SetBool("isFall", false);
    }
    // void block(){
    //     anim.SetBool("isFall", false);
    // } 

    void SetCountText(){
        countText.text = "pink donut : " + PinkDonutCount.ToString() + "\t" +"brown donut : " + BrownDonutCount.ToString();
    }
    
    // void intro(){
    //     Debug.Log("start");
    //     Vector3 targetPosition = new Vector3(17,0,9);
    //     float distance = Vector3.Distance(transform.position, targetPosition);
       
    //     Vector3 moveDirection = (targetPosition - transform.position).normalized;
    //     transform.position += moveDirection * 4 * Time.deltaTime;
    //     anim.SetBool("isWalk", true);
    //     Debug.Log("start");
    //     // Vector3 targetPosition = new Vector3(17, 0, 9);
    //     // if (Vector3.Distance(transform.position, targetPosition) > 0.1f) {  // 목표 지점에 충분히 가까워질 때까지만 이동
    //     //     Vector3 moveDirection = (targetPosition - transform.position).normalized;
    //     //     transform.position += moveDirection * 100 * Time.deltaTime;
    //     //     Debug.Log("걸어랴지?");
    //     //     anim.SetBool("isWalk", true);
    //     //     Debug.Log("난 걷는 중");
    //     // } else {
    //     //     anim.SetBool("isWalk", false);  // 목표 지점에 도달하면 걷기 애니메이션 멈춤
    //     //     Debug.Log("난 걷는 중 아님");
    //     //}
    // }
}

