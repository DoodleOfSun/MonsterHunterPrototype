using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���콺 ������ ���� ī�޶� ȸ����Ų��.
// �� Ŭ���������� �ʿ��� ������ �ʱ�ȭ�� �Լ��� �����ϰ�, ����� CameraMovingTPS���� �ϴ� ������ �Ѵ�.
public class CameraRotating : MonoBehaviour
{
    public float rotSpeed;

    float mx = 0;
    float my = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // ���콺�� Y�� �Է°��� �̿��� ī�޶��� ���Ϸ����� �����Ѵ�.
    public Vector3 RotatingByMouseY()
    {
        // Rotating Objects with Mouse Input
        float mouse_Y = Input.GetAxis("Mouse Y");

        my += mouse_Y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);

        return new Vector3 (-my, 0, 0);
    }

    // ���콺�� X�� ���� �̿��� Ÿ������ ������ ������Ʈ �ֺ��� ���ۺ��� ����.
    public void RotatingByMouseX(Vector3 targetPos)
    {
        float mouse_X = Input.GetAxis("Mouse X");

        mx += mouse_X * rotSpeed * Time.deltaTime;

        transform.RotateAround(targetPos, Vector3.up, mx);
        transform.LookAt(targetPos, Vector3.up);
    }
}