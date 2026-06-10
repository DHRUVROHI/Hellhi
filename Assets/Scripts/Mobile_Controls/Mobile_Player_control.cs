//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Mobile_Player_control : MonoBehaviour
//{
//    // Start is called before the first frame update
//    public Joystick joy_1;
//    public float speed = 5f;
 
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        float horizontal = joy_1.Horizontal;
//        float vertical = joy_1.Vertical;    

//        Vector3 move = (Camera.main.transform.forward * horizontal) + ( Camera.main.transform.right * -vertical);
//        move.y = 0;
//        transform.Translate(move * speed * Time.deltaTime);

//    }
//}
