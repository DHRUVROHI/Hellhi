using System.Collections;
using System.Collections.Generic;
using Terresquall;
using UnityEngine;

public class mobile_input : MonoBehaviour
{

    public static mobile_input instance;
 
    public bool isjumped;
    public bool isdash;
    public bool isshoot;
    public bool isheal;
    public bool isweopenchange;
    public bool ispickup;
 public VirtualJoystick joystick;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    //public float horizontal()
    //{
    //    return joystick.Horizontal;
    //}

    //public float vertical()
    //{
    //    return joystick.Vertical;
    //}

    public void jumped()
    {
        isjumped = true;
    }
    public void dash()
    {
        isdash = true;
    }
    public void shoot()
    {
        isshoot = true;
    }

    public void heal()
    {
        isheal = true;
    }
    public void weopen_switch()
        {
         isweopenchange = true;

        }
    public void Pickup()
    {
        ispickup = true;
    }

}
