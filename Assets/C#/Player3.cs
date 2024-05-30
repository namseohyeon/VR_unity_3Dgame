using UnityEngine;
using UnityEngine.UI;

public class Player3 : MonoBehaviour
{
    public float speed;
    //public Transform cameraTransform; 
    //bool wDown;

    //private Rigidbody rb;
    public int donutCount = 0;
    public int requiredDonuts = 10;
    Animator anim;
    public Text next;
    public Text countText;
    //private float timer = 0f; // 타이머를 0부터 시작하도록 초기화
    //public Text time;

    // Start is called before the first frame update
    void Start()
    {
       //rb = GetComponent<Rigidbody>(); 
       anim = GetComponentInChildren<Animator>();
       next.text = "";
       SetCountText();
       //time = GetComponent<Text>();
        //if (time == null)
        //{
            //Debug.LogError("게임 오브젝트에서 Text 컴포넌트를 찾을 수 없습니다.");
        //}
    }

    // Update is called once per frame
    void Update()
    
    {
        //timer += Time.deltaTime; 
        //if (time == null)
        //{
           // time.text = string.Format("{0:0.00}", timer); // 타이머를 소수점 두 자리로 표시
        //}
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //wDown = Input.GetButtom("walk");

        Vector3 movement = new Vector3(-moveHorizontal,0.0f,-moveVertical).normalized;

        
        //transform.Translate(0, 0, moveVertical * speed * Time.deltaTime, Space.Self);

        transform.position += movement * speed * Time.deltaTime ;

        anim.SetBool("isRun", movement != Vector3.zero );
        //anim.SetBool("isWalk", wDown);
        transform.LookAt(transform.position + movement);
    
    }
    public void IncreaseDonutCount()
    {
       donutCount++;
       SetCountText();
    }

    void SetCountText(){
        countText.text ="Count : " + donutCount.ToString();
    }

}

