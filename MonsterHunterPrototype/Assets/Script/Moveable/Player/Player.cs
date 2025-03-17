using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� Ŭ������ �÷��̾��� �Է��� ó���Ѵ�.
// ���� �ٸ� ��� �÷��̾� ���� �Լ����� �� Ŭ�������� ����Ѵ�.
public class Player : MonoBehaviour
{
    // ����ϴ� ��ũ��Ʈ ����
    private PlayerMove pm;

    // GetAxis�� �Է¹��� �� ����
    private float InputedXDir;
    private float InputedZDir;



    void Start()
    {
        Init();
    }
    private void Init()
    {
        pm = GetComponent<PlayerMove>();
        InputedXDir = 0;
        InputedZDir = 0;
    }

    void Update()
    {
        AllPlayerInput();
    }

    void FixedUpdate()
    {
        pm.MovingByDir(InputedXDir,InputedZDir);
    }

    private void AllPlayerInput()
    {
        InputedXDir = Input.GetAxis("Horizontal");
        InputedZDir = Input.GetAxis("Vertical");
    }
}