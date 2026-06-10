
using UnityEngine;


public class Camera_movement : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform target;
    public float smooth_speed = 5.0f;
    public float sensitvity = 100.0f;
    public Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        camera_movmenet();
    }

   public void camera_movmenet()
    {
        Vector3 desired_position = target.position + offset;
        transform.position  = Vector3.Lerp(transform.position, desired_position, smooth_speed *  Time.deltaTime);
    }

    //public void mouse_camera_movement()
    //{
    //    Vector3 mouse_drag = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    //    transform.rotation = Vector3.Lerp(transform.rotation , mouse_drag * sensitvity , smooth_speed * Time.deltaTime);
    //}
}
