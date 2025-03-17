using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� Ŭ������ �����̰��� �ϴ� ������Ʈ���� ���� �������� �̵� �޼ҵ带 �����Ѵ�.
public class MovingObject : MonoBehaviour
{
    public float moveSpeed;
    //protected Quaternion originalRotate;
    //protected Animator animator

    protected Rigidbody rb;

    protected Vector3 currentVelocity;

    protected virtual void Start()
    {
        //originalRotate = transform.localRotation;
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    protected void RotateMove(Transform centerTransform, Quaternion rotateOrigin)
    {
        StartCoroutine(MovingWithRotating(centerTransform, rotateOrigin));
    }

    // NOTE : �����۵��ϳ�, �������̴�.
    private void UsingRb(float xDir, float yDir)
    {
        float horizontal = rb.position.x + xDir;
        float vertical = rb.position.y + yDir;

        Vector3 targetPos = new Vector3(horizontal, vertical, 0f);
        Vector3 nextPos = Vector3.MoveTowards(transform.position, targetPos, Time.fixedDeltaTime * moveSpeed);

        rb.MovePosition(nextPos);
    }

    // NOTE : �ε巯�� �̵��� ���� SmoothDamp�� ����� �̵� ����
    protected void UsingSmoothDampByDirection(float xDir, float zDir)
    {
        // �̵� ���� ���� ���
        Vector3 direction = new Vector3(xDir, 0f, zDir).normalized;

        // ��ǥ ��ġ ��� (���� ��ġ�� �̵� ������ moveSpeed�� ���� ��)
        Vector3 targetPosition = transform.position + direction * moveSpeed * Time.fixedDeltaTime;

        // SmoothDamp�� �ε巴�� �̵�
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, 0.8f);

    }

    // UsingSmoothDamp�� Direction�� �ƴ϶� ��ǥ�� �޴� ����� �Լ�
    protected void UsingSmoothDampByPosition(Vector3 targetPos)
    {
        Vector3 direction = (targetPos - transform.position).normalized;

        // ��ǥ ��ġ ��� (���� ��ġ�� �̵� ������ moveSpeed�� ���� ��)
        Vector3 targetPosition = transform.position + direction * moveSpeed * Time.fixedDeltaTime;

        // SmoothDamp�� �ε巴�� �̵�
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
