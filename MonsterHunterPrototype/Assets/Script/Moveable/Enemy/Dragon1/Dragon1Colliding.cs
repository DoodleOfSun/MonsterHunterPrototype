using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon1Colliding : MonoBehaviour
{
    private Transform parentObject;
    private Dragon1 dragon1Script;

    // Start is called before the first frame update
    void Start()
    {
        parentObject = this.transform.parent;
        dragon1Script = parentObject.GetComponent<Dragon1>();
    }

    private void OnTriggerEnter(Collider other)
    {
        dragon1Script.Damaged(other);
    }
}
