using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_attack : MonoBehaviour
{
    // Start is called before the first frame update

  
   

    NavMeshAgent agent;
    public Transform Player;
    public GameObject dark_magic;
    public Transform dark_magic_point;
    float nextAttackTime;
    public float attackCooldown = 2f;
    public ParticleSystem[] explosion;
    public AudioSource explo;

  
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        shoot_enemy_bullet();
    }


    public void shoot_enemy_bullet()
    {
        float distance  = Vector3.Distance(transform.position, Player.position);
        if (distance < 2f)
        {
            agent.isStopped = true;
            transform.LookAt(Player);

           
            
                // Instantiate(dark_magic, dark_magic_point.position, Quaternion.identity);
                UI_Manager.instance.update_player_health(0.01f);
                explosion_vfx();
                StartCoroutine(des());
                
        }
        else
        {
        
            agent.isStopped = false;
            agent.SetDestination(Player.position);
        }
    }

    IEnumerator des()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
  
    }
  
    public void explosion_vfx()
    {
        foreach (ParticleSystem Eps in explosion)
        {

            Eps.transform.parent = null;
            Eps.Play();
            Destroy(Eps.gameObject, 1f);
            explo.Play();
        }
    }

 



}
