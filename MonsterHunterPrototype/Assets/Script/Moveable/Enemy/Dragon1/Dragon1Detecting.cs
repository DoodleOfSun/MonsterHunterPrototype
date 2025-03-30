using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon1Detecting : MonoBehaviour
{
    public float viewRange;
    public float viewAngle;
    public LayerMask targetLayer;
    private bool isDetected;

    // Start is called before the first frame update
    void Start()
    {
        isDetected = false;
    }

    public bool Detecting()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, viewRange, targetLayer);
        foreach (Collider col in colliders)
        {
            Vector3 directionToTarget = col.transform.position - transform.position;
            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

            // 시야 범위 내에 있는지, 그리고 시야 각도 내에 있는지 확인
            if (angleToTarget < viewAngle / 2)
            {
                RaycastHit hit;
                if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), directionToTarget.normalized, out hit, viewRange))
                {
                    if (hit.collider == col)
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.3f); // 반투명 빨간색
        Gizmos.DrawSphere(transform.position, 0.2f); // 시야의 중심 표시

        // 부채꼴 시야 범위를 그리기
        Vector3 forwardDirection = transform.forward;
        float angleHalf = viewAngle / 2;

        // 부채꼴의 시작과 끝 각도 계산
        Quaternion leftRotation = Quaternion.Euler(0, -angleHalf, 0);
        Quaternion rightRotation = Quaternion.Euler(0, angleHalf, 0);

        // 부채꼴의 각도를 따라 선을 그리기
        Vector3 leftEdge = transform.position + leftRotation * forwardDirection * viewRange;
        Vector3 rightEdge = transform.position + rightRotation * forwardDirection * viewRange;

        // 부채꼴 모양 그리기
        Gizmos.DrawLine(transform.position, leftEdge);
        Gizmos.DrawLine(transform.position, rightEdge);
        Vector3 midEdge = (leftEdge + rightEdge) / 2;
        midEdge = midEdge + new Vector3(0, 20f, 0);
        Gizmos.DrawLine(transform.position, midEdge);
    }

}
