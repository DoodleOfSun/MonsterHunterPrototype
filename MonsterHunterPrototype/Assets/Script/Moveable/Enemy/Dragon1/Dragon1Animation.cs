using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon1Animation : MonoBehaviour
{
    public Animator animator;

    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveOrIdleAnimation(bool isMoving)
    {

        string newState = "";

        if (!isMoving)
        {
            newState = "Idle";
        }
        else if (isMoving)
        {
            newState = "Walk";
        }


        if (newState != "" && newState != currentState)
        {
            animator.ResetTrigger(currentState); // 이전 트리거 초기화
            animator.SetTrigger(newState); // 새로운 트리거 실행
            currentState = newState; // 현재 상태 갱신
        }
    }

    public void AttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    public void ScreamAnimation()
    {
        animator.SetTrigger("Scream");
    }

    public void SleepAnimation()
    {
        animator.SetTrigger("Sleep");
    }

    public void DieAnimation()
    {
        animator.SetTrigger("Die");
    }
}
