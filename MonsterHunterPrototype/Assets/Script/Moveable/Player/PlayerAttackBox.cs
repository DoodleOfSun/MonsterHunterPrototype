using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Debug.Log(this.transform.name + "이 태그 : " + collision.transform.tag + "를 공격함이 확인됨.");
        }
    }
}
