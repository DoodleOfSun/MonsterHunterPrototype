using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 클래스는 움직이고자 하는 오브젝트들을 위한 물리적인 이동 메소드를 제공한다.
public class MovingObject : MonoBehaviour
{
    public float moveSpeed;
    //protected Quaternion originalRotate;
    //protected Animator animator
    CharacterController cc;
    protected Rigidbody rb;

    protected float currentSpeed;
    protected Vector3 currentVelocity;

    protected virtual void Start()
    {
        //originalRotate = transform.localRotation;
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        currentSpeed = moveSpeed;
    }

    protected void RotateMove(Transform centerTransform, Quaternion rotateOrigin)
    {
        StartCoroutine(MovingWithRotating(centerTransform, rotateOrigin));
    }

    // NOTE : MoveToward 사용한 이동 로직
    protected void UsingMoveTowardByDirection(float xDir, float zDir)
    {
        Vector3 dirVector3 = new Vector3(xDir, 0f, zDir);
        dirVector3 = transform.TransformDirection(dirVector3);

        Vector3 targetPos = new Vector3(this.transform.position.x + dirVector3.x, 0f, this.transform.position.z + dirVector3.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.fixedDeltaTime * moveSpeed);
    }
    

    // MoveToward을 이용해 지정한 위치로 이동하는 함수
    protected void UsingMoveTowardByPosition(Vector3 targetPosition)
    {
        float horizontal = this.transform.position.x + targetPosition.x;
        float vertical = this.transform.position.z + targetPosition.z;

        // 목표 위치 계산
        Vector3 targetPos = new Vector3(horizontal, 0f, vertical);

        // Vector3 MoveToward로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.fixedDeltaTime * moveSpeed);
    }


    // NOTE : 부드러운 이동을 위한 SmoothDamp를 사용한 이동 로직
    protected void UsingSmoothDampByDirection(float xDir, float zDir)
    {
        // 이동 방향 벡터 계산
        Vector3 direction = new Vector3(xDir, 0f, zDir).normalized;

        // 목표 위치 계산 (현재 위치에 이동 방향을 moveSpeed로 곱한 값)
        Vector3 targetPosition = transform.position + direction * moveSpeed * Time.fixedDeltaTime;

        // SmoothDamp로 부드럽게 이동
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, 1f);

    }

    // UsingSmoothDamp가 Direction이 아니라 좌표를 받는 경우의 함수
    protected void UsingSmoothDampByPosition(Vector3 targetPos)
    {
        Vector3 direction = (targetPos - transform.position).normalized;

        // 목표 위치 계산 (현재 위치에 이동 방향을 moveSpeed로 곱한 값)
        Vector3 targetPosition = transform.position + direction * moveSpeed * Time.fixedDeltaTime;

        // SmoothDamp로 부드럽게 이동
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, 50f);
    }

    protected IEnumerator UsingSmoothDampByPos(Vector3 targetPos)
    {
        while (Vector3.Distance(this.transform.position, targetPos) > 0.1f)
        {
            targetPos.z = -10f;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, 0.3f);
            newPos.y = 0f;
            transform.position = newPos;
            yield return null;
        }
    }

    private IEnumerator MovingWithRotating(Transform spinCenterTransform, Quaternion rotateOrigin)
    {
        this.transform.RotateAround(spinCenterTransform.position, Vector3.forward, moveSpeed * Time.fixedDeltaTime);
        this.transform.rotation = rotateOrigin;
        yield return null;
    }

}
