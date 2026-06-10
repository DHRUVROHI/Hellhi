
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class bullet_fire : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    
   

    // Normal fire

    public float range = 25f;
    public float duduce_Health = 10f;
    public float knockbackforce;
    public Animator shooting_anim;
    public ParticleSystem Muzzleflash;
 

    // Charge_shoot
   // public Animator Charge_shooting_anim;



    void Start()
    {
        shooting_anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(cam.transform.position, cam.transform.forward * range, Color.red);
        if (mobile_input.instance.isshoot ) 
            {
        //    
            Audio_Manager.instance.bullet_Sfx();
           // Debug.Log("Is shooting");
            shooting();


            //    Instantiate(bullet , fire_point.position , Quaternion.identity);
            //|| Input.GetMouseButton(0)
        }
    }

    public void shooting()
    {
        mobile_input.instance.isshoot = false;
        shooting_anim.SetTrigger("isshooting");
        Vfx_Manager.instance.bullet_vfx();
       // Muzzleflash.Play();

      //  Debug.Log("ISshooting_animation_working");
        RaycastHit ray;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out ray, range))
        {
           // Debug.Log("Hit" + ray.transform.name);

            if (ray.transform.CompareTag("Boss"))
            {
                //Debug.Log("Hit" + "boss");
                UI_Manager.instance.update_health(0.005f);

                Rigidbody boss_rb = ray.collider.attachedRigidbody;
                NavMeshAgent agent = boss_rb.GetComponent<NavMeshAgent>();
                Boss_fight boss_fight = ray.transform.GetComponent<Boss_fight>();
                if (agent != null)
                {
                   agent.enabled = false;
                    StartCoroutine(Enableagent(agent));
                }

                
                if(boss_rb != null)
                {
                   Vector3 dir = (ray.point - cam.transform.position).normalized;
                 //   StartCoroutine(boss_fight.Knockback(dir,5f,0.2f)); 
                  

                }
            }

            if(ray.transform.CompareTag("Enemy"))
            {
            
                Enemy_attack enemy = ray.transform.GetComponent<Enemy_attack>();
                if(enemy != null)
                {
                    enemy.explosion_vfx();
                }
                Destroy(ray.transform.gameObject);
                Audio_Manager.instance.enemy_die_Sfx();
            }
        }
    }

    IEnumerator Enableagent(NavMeshAgent agent)
    {
        yield return new WaitForSeconds(0.3f);
        if(agent != null)
        {
            agent.enabled = true;   
        }
    }

    public void charge_shooting()
    {
        
    }

    //IEnumerator shooting_animation()
    //{
    //    shooting_anim.SetBool("isshooting", true);
    //    yield return new WaitForSeconds(0.0f);
    //    shooting_anim.SetBool("isshooting", false);
    //}
}
