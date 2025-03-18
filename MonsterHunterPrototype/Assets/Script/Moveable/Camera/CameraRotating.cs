using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 마우스 각도에 따라 카메라를 회전시킨다.
// 이 클래스에서는 필요한 변수의 초기화나 함수만 선언하고, 사용은 CameraMovingTPS에서 하는 것으로 한다.
public class CameraRotating : MonoBehaviour
{
    public float rotSpeed;

    float mx = 0;
    float my = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 마우스의 Y축 입력값을 이용해 카메라의 오일러각을 대입한다.
    public Vector3 RotatingByMouseY()
    {
        // Rotating Objects with Mouse Input
        float mouse_Y = Input.GetAxis("Mouse Y");

        my += mouse_Y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);

        return new Vector3 (-my, 0, 0);
    }

    // 마우스의 X축 값을 이용해 타겟으로 정해진 오브젝트 주변을 빙글빙글 돈다.
    public void RotatingByMouseX(Vector3 targetPos)
    {
        float mouse_X = Input.GetAxis("Mouse X");

        mx += mouse_X * rotSpeed * Time.deltaTime;

        transform.RotateAround(targetPos, Vector3.up, mx);
        transform.LookAt(targetPos, Vector3.up);
    }
}