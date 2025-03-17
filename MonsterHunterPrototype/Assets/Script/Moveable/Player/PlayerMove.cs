using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� Ŭ������ �÷��̾��� �������� ����Ѵ�.
public class PlayerMove : MovingObject
{
    public float DashSpeed;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // ���� ������ ���� �����δ�.
    public void MovingByDir(float xDir, float zDir)
    {
        StartCoroutine(PlayerMoving(xDir, zDir));
    }

    private IEnumerator PlayerMoving(float xDir, float zDir)
    {
        UsingSmoothDampByDirection(xDir, zDir);
        yield return null;
    }

}
