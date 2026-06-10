using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource fire_A1;
    public AudioSource walking_A2;
    public AudioSource heal_A3;
    public AudioSource bullet_A4;
     public AudioSource enemy_die_A5;
    public AudioSource jump_scare;
    public AudioSource centepide_jumscare;
    public AudioSource centepide_jumscare_1;
    public AudioSource Rumble_sfx;

    public AudioSource radio_s1;
    public AudioSource radio_s2;
    public AudioSource radio_s3;
    public AudioSource boss_music_1;

    public static Audio_Manager instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fireball_sfx()
    {
        fire_A1.Play();
    }

    public void randomwalk_pitch()
    {
        walking_A2.pitch = Random.Range(0.95f, 1.5f);
    }
    public void walking_skx()
    {
        if(!walking_A2.isPlaying)
        {
            walking_A2.Play();
        }
    

    }
    public void walking_skx_sstop()
    {
        if (walking_A2.isPlaying)
        {
            walking_A2.Stop();
        }
       

    }
    public void heal_sfx()
    {
        heal_A3.Play();
    }
    public void bullet_Sfx()
    {
        bullet_A4.Play();
    }

    public void enemy_die_Sfx()
    {
       enemy_die_A5.Play();
    }

    public void jump_scare_sfx()
    {
        jump_scare.Play();
    }

    public void centepide_jumpscare_sound()
    {
        centepide_jumscare.Play();
        centepide_jumscare_1.Play();
    }
    public void Rumble()
    {
        Rumble_sfx.Play();
    }
    public void Radio()
    {
        radio_s1.Play();
        StartCoroutine(nextradio_voice());
        
    }

    public void Boss_fight_music()
    {
        boss_music_1.Play();
    }
 IEnumerator nextradio_voice()
    {
        yield return new WaitForSeconds(3f);
        radio_s2.Play();
        radio_s3.Play();
        yield return new WaitForSeconds(13f);
        radio_s1.Play();
        radio_s2.Stop();
        radio_s3.Play();

    }
   
}
