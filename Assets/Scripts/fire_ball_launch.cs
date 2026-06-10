
using System.Collections;
using UnityEngine;

public class fire_ball_launch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireball;
    public Transform fireball_point;
    public Animator fireball_anim;
    void Start()
    {
        fireball_anim = GetComponentInChildren<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if ( mobile_input.instance.isshoot )
        {
          StartCoroutine(maze_anim_controller());
            Audio_Manager.instance.fireball_sfx();
            mobile_input.instance.isshoot = false;
          
        }
        if ( mobile_input.instance.isheal)
        {
            heal_shoot();
            Audio_Manager.instance.heal_sfx();
            mobile_input.instance.isheal = false;
        }
    }

    IEnumerator maze_anim_controller()
    {
        fireball_anim.SetBool("is_fireball_shoot", true);
        yield return new WaitForSeconds(0.20f);
        fire_ball_shoot();
        yield return new WaitForSeconds(0.10f);
        fireball_anim.SetBool("is_fireball_shoot", false);
        
    }
    public void fire_ball_shoot()
    {
        Instantiate(fireball,fireball_point.position,fireball_point.rotation);
    }

     public void heal_shoot()
    {
        UI_Manager.instance.heal_health(0.02f);
        Vfx_Manager.instance.heal_vfx();
    }


   
}
