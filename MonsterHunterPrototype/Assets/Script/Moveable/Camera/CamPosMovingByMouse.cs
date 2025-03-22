using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPosMovingByMouse : MonoBehaviour
{
    private float mouseX = 0;
    private float originMouseX = 0;


    public float rotSpeed;
    public GameObject targetObj;


    // Start is called before the first frame update
    void Start()
    {
        originMouseX = mouseX;
    }

    // Update is called once per frame
    void Update()
    {
        MovingByMouseX(targetObj.transform.position);
    }

    public void MovingByMouseX(Vector3 targetPos)
    {
        float mouse_X = 0;
        float leftWidthMargin = 0.2f;
        float rightWidthMargin = 0.8f;

        // 마우스 위치에 따라서 mouse_X를 다르게 설정을 한다.
        // 왼쪽
        if (Input.mousePosition.x < Screen.width * leftWidthMargin)
        {
            mouse_X = 1f;
        }

        // 중앙
        else if (Input.mousePosition.x >= Screen.width * leftWidthMargin && Input.mousePosition.x < Screen.width * rightWidthMargin)
        {
            mouse_X = 0f;
        }

        // 오른쪽
        else if(Input.mousePosition.x >= Screen.width * rightWidthMargin)
        {
            mouse_X = -1f;
        }

        // 이전과 동일한 위치에 마우스가 위치하는지 확인 
        // 계속 돌리기 위해 존재하는 로직임.
        // 만약에 다른 곳으로 이동했으면 0으로 초기화한다.
        if (mouse_X != originMouseX)
        {
            mouseX = 0;
        }

        // 실질적인 카메라 이동 로직
        mouseX += mouse_X * rotSpeed * Time.deltaTime;

        transform.RotateAround(targetPos, Vector3.up, mouseX);
        transform.LookAt(targetPos, Vector3.up);

        originMouseX = mouse_X; // 이전 값을 저장한다.
    }
}