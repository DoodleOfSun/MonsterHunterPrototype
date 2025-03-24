using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public GameObject camObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerRotatingByMouseX()
    {
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, camObject.transform.eulerAngles.y, this.transform.eulerAngles.z);
    }
}