using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon1Colliding : MonoBehaviour
{
    private Transform parentObject;
    private Dragon1 dragon1Script;

    public Text enemyText;

    // Start is called before the first frame update
    void Start()
    {
        parentObject = this.transform.parent;
        dragon1Script = parentObject.GetComponent<Dragon1>();
    }

    void Update()
    {
        enemyText.text = "Dragon1 Damaged : False"; 
    }

    private void OnTriggerEnter(Collider other)
    {
        enemyText.text = "Dragon1 Damaged : True";
        dragon1Script.Damaged(other);
    }
}
