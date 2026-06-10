using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn_Manager : MonoBehaviour
{

    public static Spawn_Manager instance;

    
    // Start is called before the first frame update
    public GameObject boss;
    public GameObject boss_Ui;
    public GameObject spawn_enemy_1;
    public GameObject spawn_enemy_2;
    public GameObject spawn_enemy_3;
    public GameObject spawn_enemy_4;
    public GameObject spawn_enemy_5;
    public Animator enemy_anim;
    

    private void Awake()
    {
        if (instance == null)
        { 
        instance = this;
    }

        else
        {
            Destroy(instance);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void active_boss()
    {
        boss.SetActive(true);
        boss_Ui.SetActive(true);
        Vfx_Manager.instance.vfx_meteorite();
    }

    public void active_Enemey_1_wave()
    {
        spawn_enemy_1.SetActive(true);
    }

    public void active_Enemey_2_wave()
    {
        spawn_enemy_2.SetActive(true);
    }

    public void active_Enemey_3_wave()
    {
        spawn_enemy_3.SetActive(true);
    }

    public void active_Enemey_4_wave()
    {
        spawn_enemy_4.SetActive(true);
    }

    public void active_Enemey_5_wave()
    {
        spawn_enemy_5.SetActive(true);
    }


    public void Jump_scare()
    {
        enemy_anim.SetTrigger("Jump_scare");
        Audio_Manager.instance.jump_scare_sfx();
    }

}
