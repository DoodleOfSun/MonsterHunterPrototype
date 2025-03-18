using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라의 움직임에 대한 모든 함수를 이곳에서 실행한다.
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