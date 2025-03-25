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
    private PlayerRotate pr;

    // 플레이어의 I/O 입력
    private float InputedXDir;
    private float InputedZDir;
    private bool isLeftClick;
    private bool isRightClick;

    // 딜레이 처리를 위한 코루틴
    private Coroutine attackDelayCoroutine;
    private Coroutine parryDelayCoroutine;


    void Start()
    {
        Init();
    }
    
    private void Init()
    {
        pm = GetComponent<PlayerMove>();
        pa = GetComponent<PlayerAnimation>();
        pr = GetComponent<PlayerRotate>();

        InputedXDir = 0;
        InputedZDir = 0;

        attackDelayCoroutine = null;
        parryDelayCoroutine = null;
    }

    void Update()
    {
        AllPlayerInput();
        AnimationPlay();
        pr.PlayerRotatingByMouseX();
    }

    void FixedUpdate()
    {
        pm.MovingByDir(InputedXDir,InputedZDir);
    }

    private void AllPlayerInput()
    {
        InputedXDir = Input.GetAxis("Horizontal");
        InputedZDir = Input.GetAxis("Vertical");
        isLeftClick = Input.GetMouseButtonDown(0);
        isRightClick = Input.GetMouseButtonDown(1);
    }

    private void AnimationPlay()
    {

        if (attackDelayCoroutine == null && isLeftClick)
        {
            Debug.Log("공격");
            attackDelayCoroutine = StartCoroutine(DelayWhileAttacking());
        }

        if (parryDelayCoroutine == null && isRightClick)
        {
            Debug.Log("패리");
            parryDelayCoroutine = StartCoroutine(DelayWhileParrying());
        }

        if (attackDelayCoroutine == null && parryDelayCoroutine == null)
        {
            pa.MovingAnimation(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }

    // HACK : 대기 시간 도중에 좌클릭이 들어오면 
    private IEnumerator DelayWhileAttacking()
    {
        pa.AttackAnimation(isLeftClick);
        pm.PlayerFreeze();
        yield return new WaitForSeconds(0.5f);
        pm.PlayerSpeedReturnToOrigin();
        attackDelayCoroutine = null;
        pa.MakeEmptyCurrentState();
    }

    private IEnumerator DelayWhileParrying()
    {
        pa.ParryAnimation(isRightClick);
        pm.PlayerFreeze();
        yield return new WaitForSeconds(0.5f);
        pm.PlayerSpeedReturnToOrigin();
        parryDelayCoroutine = null;
        pa.MakeEmptyCurrentState();
    }


}