using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 클래스는 플레이어의 입력을 처리한다.
// 또한 다른 모든 플레이어 관련 함수들을 이 클래스에서 사용한다.


public class Player : MonoBehaviour
{
    // 상태머신 정의
    private enum PlayerState
    {
        Idle,
        Attack,
        Damage,
        Walk,
        Run,
        Die
    }

    // 사용하는 스크립트 정의
    private PlayerMove pm;
    private PlayerAnimation pa;

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
        pa = GetComponent<PlayerAnimation>();

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