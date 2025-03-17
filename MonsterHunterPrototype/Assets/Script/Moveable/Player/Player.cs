using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 클래스는 플레이어의 입력을 처리한다.
// 또한 다른 모든 플레이어 관련 함수들을 이 클래스에서 사용한다.
public class Player : MonoBehaviour
{
    // 사용하는 스크립트 정의
    private PlayerMove pm;

    // GetAxis로 입력받은 각 방향
    private float InputedXDir;
    private float InputedZDir;



    void Start()
    {
        Init();
    }
    private void Init()
    {
        pm = GetComponent<PlayerMove>();
        InputedXDir = 0;
        InputedZDir = 0;
    }

    void Update()
    {
        AllPlayerInput();
    }

    void FixedUpdate()
    {
        pm.MovingByDir(InputedXDir,InputedZDir);
    }

    private void AllPlayerInput()
    {
        InputedXDir = Input.GetAxis("Horizontal");
        InputedZDir = Input.GetAxis("Vertical");
    }
}