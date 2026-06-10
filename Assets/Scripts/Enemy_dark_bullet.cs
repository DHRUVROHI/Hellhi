using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_dark_bullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bullet_fire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    public void bullet_fire()
    {
        rb.velocity = rb.transform.forward * speed;
        Invoke("fire_ball_destroy", 2f);
    }
    public void fire_ball_destroy()
    {
        Destroy(gameObject);
    }


}
