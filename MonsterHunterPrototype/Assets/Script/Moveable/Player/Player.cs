using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� Ŭ������ �÷��̾��� �Է��� ó���Ѵ�.
// ���� �ٸ� ��� �÷��̾� ���� �Լ����� �� Ŭ�������� ����Ѵ�.


public class Player : MonoBehaviour
{
    // ���¸ӽ� ����
    private enum PlayerState
    {
        Idle,
        Attack,
        Damage,
        Walk,
        Run,
        Die
    }

    // ����ϴ� ��ũ��Ʈ ����
    private PlayerMove pm;
    private PlayerAnimation pa;

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
        pa = GetComponent<PlayerAnimation>();

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