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

        // ���콺 ��ġ�� ���� mouse_X�� �ٸ��� ������ �Ѵ�.
        // ����
        if (Input.mousePosition.x < Screen.width * leftWidthMargin)
        {
            mouse_X = 1f;
        }

        // �߾�
        else if (Input.mousePosition.x >= Screen.width * leftWidthMargin && Input.mousePosition.x < Screen.width * rightWidthMargin)
        {
            mouse_X = 0f;
        }

        // ������
        else if(Input.mousePosition.x >= Screen.width * rightWidthMargin)
        {
            mouse_X = -1f;
        }

        // ������ ������ ��ġ�� ���콺�� ��ġ�ϴ��� Ȯ�� 
        // ��� ������ ���� �����ϴ� ������.
        // ���࿡ �ٸ� ������ �̵������� 0���� �ʱ�ȭ�Ѵ�.
        if (mouse_X != originMouseX)
        {
            mouseX = 0;
        }

        // �������� ī�޶� �̵� ����
        mouseX += mouse_X * rotSpeed * Time.deltaTime;

        transform.RotateAround(targetPos, Vector3.up, mouseX);
        transform.LookAt(targetPos, Vector3.up);

        originMouseX = mouse_X; // ���� ���� �����Ѵ�.
    }
}