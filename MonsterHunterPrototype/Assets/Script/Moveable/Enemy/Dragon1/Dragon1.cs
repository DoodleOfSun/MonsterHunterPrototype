using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon1 : MonoBehaviour
{
    // 사용하는 스크립트 참조
    private Dragon1Animation d1a;
    private Dragon1Detecting d1d;

    public enum Dragon1State
    {
        Idle,
        Detect,
        Attack,
        Move,
        Sleep,
        Die
    }


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        d1a = GetComponent<Dragon1Animation>();
        d1d = GetComponent<Dragon1Detecting>();
    }

    // Update is called once per frame
    void Update()
    {
        d1d.Detecting();
    }
}
