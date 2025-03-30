using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraginAttackBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log(transform.name + "가 해당 tag를 공격함 : " + collision.transform.tag);
        }
    }
}
