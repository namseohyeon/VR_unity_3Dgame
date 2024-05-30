using UnityEngine;

public class camera : MonoBehaviour
{

    public Transform target; // 카메라가 따라갈 대상
    public Vector3 offset; // 대상에 대한 상대적 위치 (거리를 늘림)
    public float followSpeed = 10f; // 카메라가 따라가는 속도
    public float fixedXRotation = 15f;
    

    void LateUpdate()
    {
        if (target == null)
            return;

        // // 대상의 위치와 오프셋을 조합해 목표 위치 계산
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        //Vector3 desiredPosition = target.position - target.forward * offset.magnitude;
        
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        //        // 대상을 바라보는 회전 설정
        // transform.LookAt(target);

        // // X축 회전 각도를 고정
        // transform.Rotate(fixedXRotation, 0, 0);

        //X축 회전 각도를 고정하여 카메라 회전 설정
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        targetRotation *= Quaternion.Euler(fixedXRotation, 0, 0); // X축 회전만 적용

        transform.rotation = targetRotation;
    }
}