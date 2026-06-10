

using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Boss_fight : MonoBehaviour
{

    public Transform Player;
    public Transform Boss_default_position;
    public Transform wall_distance_position;
    NavMeshAgent agent;
    public Vector3 offset;
    public float next_attack_time;
    public float attack_cooldown = 3f;
    public LayerMask wall_layer;
  
    Animator anim;
    bool isswordattacking;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
       Collider collider = GetComponentInChildren<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        attack_pattern();
    }

    public void attack_pattern()
    {
        float distance = Vector3.Distance(transform.position, Player.position);
        float wall_distance = Vector3.Distance(transform.position, wall_distance_position.position);

        if (wall_distance < 5f)
        {
            agent.SetDestination(Boss_default_position.transform.position);
        }

        if (distance < 15f  )
        {
            if(agent.enabled && agent.isOnNavMesh)
            {
                agent.SetDestination(Player.position);
            }
         
            anim.SetBool("Isslampattack", true);
            Boss_Laser.Instance.stop_Laser();
        }

       
        else
        {
            if(agent.enabled && agent.isOnNavMesh)
            {
                agent.SetDestination(Boss_default_position.transform.position);
            }
            
            anim.SetBool("Isslampattack", false);
            int attack_patt = Random.Range(0, 2);
            decide_attack_pattern(attack_patt);
        }
    }

    public void decide_attack_pattern(float attack_pattrn)
    {
        switch (attack_pattrn)
        {
            case 0:
                if (!isswordattacking)
                {
                    Boss_Laser.Instance.shootlaser();
                }
                 break;
            case 1:
               
                if(Time.time >= next_attack_time)
                {
                    isswordattacking = true;
                    Boss_sword_attack.instance.sword_attack();
                    next_attack_time = Time.time + attack_cooldown;
                    isswordattacking = false;
                }
                break;
        }

    }

    //public IEnumerator Knockback(Vector3 direction,float force,float duration)
    //{
    //    agent.isStopped = true;
    // //   agent.enabled = false;
    //    float timer = 0f;
    //    while(timer < duration)
    //    {
    //        Vector3 origin = transform.position + Vector3.up * 1f;

    //        if (!Physics.Raycast(origin, direction , 1f , wall_layer))
    //        {
    //       agent.Move(direction * force * Time.deltaTime);
              
    //        }
    //        timer += Time.deltaTime;
    //        yield return null;
    //    }
    //   // agent.enabled = true;
    //    agent.isStopped = false;

    //}





}
