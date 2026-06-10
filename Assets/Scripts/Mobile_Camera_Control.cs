using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile_Camera_Control : MonoBehaviour
{
    // Start is called before the first frame update



    public Transform playerBody;
    public float sensitivity = 0.2f;

    float xRotation;


    void Start()
    {

    }
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x > Screen.width / 2)
            {
                float touchX = touch.deltaPosition.x * sensitivity;
                float touchY = touch.deltaPosition.y * sensitivity;

                xRotation -= touchY;
                xRotation = Mathf.Clamp(xRotation, -80f, 80f);

                transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

                playerBody.Rotate(Vector3.up * touchX);
            }
        }
    }
    // Update is called once per frame
    
}
