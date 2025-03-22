using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotateByMouse : MonoBehaviour
{
    public float rotSpeed;
    private float mx = 0;
    private float my = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotatingByMouse();
    }

    private void CameraRotatingByMouse()
    {
        // Rotating Objects with Mouse Input
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);

        transform.eulerAngles = new Vector3(-my, transform.eulerAngles.y, 0);
    }
}