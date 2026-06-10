using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interact : MonoBehaviour
{
    public static Interact instance;
    public Transform holdpoint;
    public float pickup_range = 3f;
    public  GameObject heldobject;
    // Start is called before the first frame update

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;    
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray_ui = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit_ui;
        if (Physics.Raycast(ray_ui, out hit_ui, pickup_range))
        {
            if (hit_ui.collider.CompareTag("Pick_up"))
            {
                UI_Manager.instance.hand_ui();
            }
        
        }
        else
        {
            UI_Manager.instance.toggle_hand_ui();
        }


        if (Input.GetKeyDown(KeyCode.E) || mobile_input.instance.ispickup)
        {
            if (heldobject == null)

            {
                Interactt();
            }
            else
            {
                Drop();
            }
            mobile_input.instance.ispickup = false;
        }
    }


  void Interactt()
    {
        mobile_input.instance.isshoot = false;

        // Muzzleflash.Play();
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
         RaycastHit hit;

        Debug.DrawRay(ray.origin , ray.direction* pickup_range,Color.magenta);

        if (Physics.Raycast(ray, out hit,pickup_range))
        {
         // Debug.Log("Hit" + hit.transform.name);

            if (hit.collider.CompareTag("Pick_up"))
            {
               // Debug.Log("Hit");
                heldobject = hit.collider.gameObject;

                Rigidbody rb  = heldobject.GetComponent<Rigidbody>();     

                rb.isKinematic = true;
                rb.useGravity = false;
                
                heldobject.transform.position  = holdpoint.transform.position;

                heldobject.transform.SetParent(holdpoint);
                heldobject.transform.localRotation = Quaternion.identity;


            }

        }
    }

    void Drop()
    {
        Rigidbody rb = heldobject.GetComponent<Rigidbody>();
        heldobject.transform.SetParent(null);
        rb.isKinematic = false;
        rb.useGravity = true;
        heldobject = null;
    }

    

}
