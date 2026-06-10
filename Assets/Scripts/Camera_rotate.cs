using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerbody;
    public float mouse_sensitivity = 100f;
    float XRotation = 0f;
    float YRotation = 0f;
  




    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        float mouseX = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        //Debug.Log("MouseX : " + mouseX);
        float mousey = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;
        YRotation -= mousey;
        XRotation += mouseX;
        YRotation = Mathf.Clamp(YRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(YRotation,0 , 0);  
        playerbody.Rotate(Vector3.up * mouseX);
        //Debug.Log(playerbody.rotation.eulerAngles);
#endif

    }
}
