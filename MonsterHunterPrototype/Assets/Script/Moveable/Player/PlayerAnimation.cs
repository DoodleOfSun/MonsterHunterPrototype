using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// 이 클래스에서는 애니메이션의 재생을 관리한다.
public class PlayerAnimation : MonoBehaviour
{
    // 애니메이터
    public Animator animator;
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MovingAnimation(float x, float y, bool isDash)
    {
        string newState = "";

        if (x == 0 && y == 0)
        {
            newState = "Idle";
        }
        else if (isDash && x != 0 || isDash && y != 0)
        {
            newState = "Sprint";
        }
        else if (x == 1 && y == 0)
        {
            newState = "Right";
        }
        else if (x == -1 && y == 0)
        {
            newState = "Left";
        }
        else if (x == 0 && y == 1)
        {
            newState = "Forward";
        }
        else if (x == 1 && y == 1)
        {
            newState = "ForwardRight";
        }
        else if (x == -1 && y == 1)
        {
            newState = "ForwardLeft";
        }
        else if (x == 0 && y == -1)
        {
            newState = "Backward";
        }
        else if (x == -1 && y == -1)
        {
            newState = "BackwardLeft";
        }
        else if (x == 1 && y == -1)
        {
            newState = "BackwardRight";
        }

        if (newState != "" && newState != currentState)
        {
            animator.ResetTrigger(currentState); // 이전 트리거 초기화
            animator.SetTrigger(newState); // 새로운 트리거 실행
            currentState = newState; // 현재 상태 갱신
        }
    }

    public void DamagedAnimation()
    {
        animator.SetTrigger("Damaged");
    }

    public void AttackAnimation(bool isLeftClick)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (isLeftClick)
        {
            animator.SetTrigger("Attack");
        }
    }
    
    public void ParryAnimation(bool isRightClick)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (isRightClick)
        {
            animator.SetTrigger("Parry");
        }
    }
}
