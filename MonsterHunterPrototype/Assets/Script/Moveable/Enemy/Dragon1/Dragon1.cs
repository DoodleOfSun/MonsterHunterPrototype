using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon1 : MonoBehaviour
{
    public GameObject target;

    private enum Dragon1State
    {
        Idle,
        Battle,
        Move,
        Sleep,
        Die
    }

    // 사용하는 스크립트 참조
    private Dragon1Animation d1Ani;
    private Dragon1Attack d1Attack;
    private Dragon1Detecting d1d;
    private Dragon1Move d1m;

    private Coroutine stateCoroutine;

    private Dragon1State state;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        d1Ani = GetComponent<Dragon1Animation>();
        d1d = GetComponent<Dragon1Detecting>();
        d1m = GetComponent<Dragon1Move>();
        d1Attack = GetComponent<Dragon1Attack>();

        state = Dragon1State.Idle;
        stateCoroutine = null;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
    }

    private void StateMachine()
    {
        switch (state)
        {
            case Dragon1State.Idle:
                if (d1d.Detecting() && stateCoroutine == null)
                {
                    stateCoroutine = StartCoroutine(FirstDetecting());
                }
                break;
            case Dragon1State.Battle:

                // 타겟이 나한테서 멀어졌음을 감지하는 코드
                if (Vector3.Distance(this.transform.position, target.transform.position) >= 10f)
                {
                    if (stateCoroutine == null)
                    {
                        stateCoroutine = StartCoroutine(ChangeToMoveCoroutine());
                    }
                }

                else if (stateCoroutine == null)
                {
                    stateCoroutine = StartCoroutine(AttackCoroutine());
                }
                break;

            case Dragon1State.Move:

                if (!d1m.IsMovingStopped())
                {
                    d1Ani.MoveOrIdleAnimation(!d1m.IsMovingStopped());
                    d1m.Move();
                }
                
                else if (d1m.IsMovingStopped() && stateCoroutine == null)
                {
                    Debug.Log("플레이어 가까워져서 이동 멈춤, 공격으로 전환, isStopped를 true로 전환");
                    stateCoroutine = StartCoroutine(ChangingStateAttackByCheckingMovingStopped());
                    d1m.StopMoving();
                }
                break;

            case Dragon1State.Sleep:

                break;

            case Dragon1State.Die:
                
                break;
        }
    }

    private IEnumerator FirstDetecting()
    {
        d1Ani.ScreamAnimation();
        yield return new WaitForSeconds(2.5f);
        state = Dragon1State.Move;
        stateCoroutine = null;
    }

    private IEnumerator ChangingStateAttackByCheckingMovingStopped()
    {
        state = Dragon1State.Battle;
        yield return null;
        stateCoroutine = null;
    }

    private IEnumerator AttackCoroutine()
    {
        d1Ani.AttackAnimation();
        yield return new WaitForSeconds(1f);
        d1Attack.Attack(transform.position, transform.forward);
        yield return new WaitForSeconds(2f);
        stateCoroutine = null;
    }

    // 이거는 이동을 시키는 코루틴인데, 이동을 시키는 동안 아무 검사도 시키질 말아야 한다. 
    // 그 이유는 움직여서 magnitude가 0이 아니게 될 때 까지정도는 움직여줘야 정상적으로 움직이기 시작하기 때문에
    // 조금의 딜레이를 주고 Move로 전환시킨다.
    private IEnumerator ChangeToMoveCoroutine()
    {
        Debug.Log("이동으로 전환");
        d1Ani.MoveOrIdleAnimation(false);
        d1m.Move();
        yield return new WaitForSeconds(1f);
        state = Dragon1State.Move;
        stateCoroutine = null;
    }

    public void Damaged(Collider other)
    {
        // 만약에 태그가 플레이어의 히트박스인 경우
        if (other.tag == "PlayerAttackBox" && state == Dragon1State.Sleep)
        {
            Die();
        }
        else if (other.tag == "PlayerAttackBox")
        {
            Sleep();
        }
    }

    private void Sleep()
    {
        d1Ani.SleepAnimation();
        d1m.StopMoving();
        state = Dragon1State.Sleep;
    }

    private void Die()
    {
        d1Ani.DieAnimation();
        d1m.StopMoving();
        state = Dragon1State.Die;
    }

}
