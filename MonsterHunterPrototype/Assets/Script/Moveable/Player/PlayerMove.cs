using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 클래스는 플레이어의 움직임을 담당한다.
public class PlayerMove : MovingObject
{
    public float DashSpeed;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // 받은 방향을 통해 움직인다.
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
