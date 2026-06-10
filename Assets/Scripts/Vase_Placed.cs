using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase_Placed : MonoBehaviour
{

    public GameObject hold_point;
    bool already_placed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Hit");
           if (already_placed) return;
        switch (other.tag)
            {
                case ("Pick_up"):
                if (other.CompareTag("Pick_up"))
                    {
                    already_placed = true;
                    placing_vase(other);
                    }
                    break;
                case ("Pick_up_1"):
                if (other.CompareTag("Pick_up_1"))
                    {
                    already_placed = true;
                    placing_vase(other);
                    }
                    break;
                case ("Pick_up_2"):
                if (other.CompareTag("Pick_up_2"))
                    {
                    already_placed = true;
                    placing_vase(other);
                    }
                    break;
                
            }
        
    }

    public void placing_vase(Collider other)
    {


        Rigidbody rb = other.GetComponent<Rigidbody>();

        rb.isKinematic = true;
        rb.useGravity = false;

        other.transform.position = hold_point.transform.position;

        other.transform.SetParent(hold_point.transform, true);
        other.transform.localPosition = Vector3.zero;
        other.transform.localRotation = Quaternion.identity;
        other.GetComponent<Collider>().enabled = false;
        other.tag = "Untagged";
        Interact.instance.heldobject = null;
        Puzzle_manager.instance.Addvase();


    }
}