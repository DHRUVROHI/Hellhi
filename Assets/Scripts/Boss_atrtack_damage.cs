using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_atrtack_damage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            UI_Manager.instance.update_player_health(0.1f);
            
        }
    }

    public void boss_vfx()
    {
        Vfx_Manager.instance.boss_vfx_play();
    }

   

}
