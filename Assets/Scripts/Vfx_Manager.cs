
using UnityEngine;


public class Vfx_Manager : MonoBehaviour
{

   public  static  Vfx_Manager instance;
    //player_vfx
    public ParticleSystem[] bullet_1;


    //boss_vfx
    public ParticleSystem[] boss_vfx;

    public ParticleSystem[] heall_vfx;
    public GameObject meteorite_vfx; 

  //  public ParticleSystem[] explosion_vfx;


    // Start is called before the first frame update

    private void Awake()
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

    public void boss_vfx_play()
    {
        foreach (ParticleSystem bps in boss_vfx)
        {
            bps.Play();
        }


    }


    public void bullet_vfx()
    {
  
       foreach (ParticleSystem ps in bullet_1)
        {
            ps.Play();
        }
    }

    public void heal_vfx()
    {
        foreach (ParticleSystem ds in heall_vfx)
        {
            ds.Play();
        }
    }

    public void vfx_meteorite()
    {
        meteorite_vfx.SetActive(true);
    }
    //public void Explosion_vfx()
    //{
    //    foreach (ParticleSystem ms in explosion_vfx)
    //    {
    //        ms.Play();
    //    }
    //}

}
