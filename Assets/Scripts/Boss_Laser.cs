using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public static Boss_Laser Instance;  



    public Transform firepoint;
    public float range = 100f;
    public float damage = 5f;
    public float firerate = 2f;

   //     float nextfiretime = 0f;
    LineRenderer lineRenderer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    
    void Update()
    {
        //if (Time.time > nextfiretime) 
        
        //{

        //    shootlaser();
        //    nextfiretime = Time.time + firerate;
        
        //}
    }


    public void shootlaser()
    {
        RaycastHit hit;
        Vector3 end;

        Vector3 start = firepoint.position;
        Vector3 direction = firepoint.forward;
        Debug.DrawRay(start, direction * range, Color.red, 1f);
        if (Physics.Raycast(start , direction , out hit ,range ))
        {
       
            end = hit.point;
          
         
            if(hit.transform.CompareTag("Player"))
            {
               Vector3 KnockbackDir = ( hit.transform.position - transform.position).normalized;
                Player_movement.instance.knockback(KnockbackDir);
                UI_Manager.instance.update_player_health(0.2f);
            }
        }

        else
        {
            end = start + direction * range;
        }


        StartCoroutine(Showlaser(start, end));

        

    }

    IEnumerator Showlaser(Vector3 start , Vector3 end)
    {
   
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        yield return new WaitForSeconds(0.1f);
       // lineRenderer.enabled=false; 
    }

    public void stop_Laser()
    {
        lineRenderer.enabled = false;
    }
}
