using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ī�޶��� �����ӿ� ���� ��� �Լ��� �̰����� �����Ѵ�.
public class CameraMovingTPS : MonoBehaviour
{
    public GameObject playerObject;

    private CameraRotating cr;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        cr = GetComponent<CameraRotating>();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustingCamera();
    }

    private void AdjustingCamera()
    {
        cr.RotatingByMouseX(playerObject.transform.position);
    }
}