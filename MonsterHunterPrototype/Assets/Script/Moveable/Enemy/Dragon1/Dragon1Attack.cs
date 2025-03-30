using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon1Attack : MonoBehaviour
{
    public GameObject attackBoxHolder;
    public GameObject attackBox;
    public float attackBoxDuration;
    public float attackDirection;


    void Start()
    {
        Init();
    }

    private void Init()
    {
        attackBox = Instantiate(attackBox, attackBoxHolder.transform);
        attackBox.SetActive(false);
    }

    public void Attack(Vector3 targetPos, Vector3 targetForward)
    {
        StartCoroutine(AttackCoroutine(new Vector3(targetPos.x, targetPos.y + 1.5f, targetPos.z) + targetForward * attackDirection));
    }

    private IEnumerator AttackCoroutine(Vector3 targetPos)
    {
        yield return new WaitForSeconds(0.5f);
        attackBox.SetActive(true);
        attackBox.transform.position = targetPos;
        yield return new WaitForSeconds(attackBoxDuration);
        attackBox.SetActive(false);
    }
}
