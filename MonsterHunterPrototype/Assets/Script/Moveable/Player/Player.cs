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

    // 플레이어의 I/O 입력
    private float InputedXDir;
    private float InputedZDir;
    private bool isShift;
    private bool isLeftClick;
    private bool isRightClick;

    // 딜레이 처리를 위한 코루틴
    private Coroutine attackAniCoroutine;
    private Coroutine parryAniCoroutine;


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
        isShift = false;

        attackAniCoroutine = null;
        parryAniCoroutine = null;
    }

    void Update()
    {
        AllPlayerInput();
        AnimationPlay();
    }

    void FixedUpdate()
    {
        pm.MovingByDir(InputedXDir,InputedZDir, isShift);
    }

    private void AllPlayerInput()
    {
        InputedXDir = Input.GetAxis("Horizontal");
        InputedZDir = Input.GetAxis("Vertical");
        isShift = Input.GetButton("Fire3");
        isLeftClick = Input.GetMouseButtonDown(0);
        isRightClick = Input.GetMouseButtonDown(1);
    }

    private void AnimationPlay()
    {
        pa.MovingAnimation(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), isShift);

        if (attackAniCoroutine == null && isLeftClick)
        {
            Debug.Log("공격 발동됨");
            attackAniCoroutine = StartCoroutine(AttackAnimationWithDelay());
        }
        else if (parryAniCoroutine == null && isRightClick)
        {
            Debug.Log("패리 발동됨");
            parryAniCoroutine = StartCoroutine(ParryAnimationWithDelay());
        }
    }

    private IEnumerator AttackAnimationWithDelay()
    {
        pa.AttackAnimation(isLeftClick);
        yield return new WaitForSeconds(0.5f);
        attackAniCoroutine = null;
    }

    private IEnumerator ParryAnimationWithDelay()
    {
        pa.ParryAnimation(isRightClick);
        yield return new WaitForSeconds(0.5f);
        parryAniCoroutine = null;
    }

}