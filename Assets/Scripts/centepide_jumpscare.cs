using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class centepide_jumpscare : MonoBehaviour
{

    NavMeshAgent agent;
   public  Transform player;
    public GameObject jumpscare_effects;
    public float offset = 1f;
    bool isjumpscare = false;
  

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        centepide_follow();
    }

    public void centepide_follow()
    {
        if(!agent.enabled) return;
        float distance = Vector3.Distance(transform.position, player.position);
      
        if(distance < 2f && !isjumpscare)
        {
            isjumpscare = true;
            StartCoroutine(jumpscare());
        }
        else
        {
            agent.isStopped = false;
            if(agent.isOnNavMesh)
            {
                agent.SetDestination(player.position);
            }
           
        }
    }

    IEnumerator jumpscare()
    {
        agent.enabled = false;
        transform.position = player.position  - player.forward * offset;
        Camera_shake.instance.startshake(3,20);
        Audio_Manager.instance.centepide_jumpscare_sound();
        transform.LookAt(player);
        jumpscare_effects.SetActive(true);
        
        yield return new WaitForSeconds(3f);
        Scene_Manager.instance.Scene_Managerr();
    }
}
