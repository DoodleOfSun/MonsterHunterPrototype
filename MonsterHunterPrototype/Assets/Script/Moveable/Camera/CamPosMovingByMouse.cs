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
        //MovingByMouseX(targetObj.transform.position);
    }

    public void MovingByMouseX(Vector3 targetPos)
    {
        float mouse_X = Input.GetAxisRaw("Mouse X");

        if (mouse_X == 0)
        {
            mouseX = 0;
        }
        else if (mouse_X < 0)
        {
            mouseX *= -1;
        }


        // 실질적인 카메라 이동 로직
        mouseX += mouse_X * rotSpeed * Time.deltaTime;

        transform.RotateAround(targetPos, Vector3.up, mouseX);
        transform.LookAt(targetPos, Vector3.up);

        originMouseX = mouse_X; // 이전 값을 저장한다.
    }
}