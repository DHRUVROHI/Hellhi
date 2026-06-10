
using UnityEngine;

public class bullet_speed : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float speed;

    void Start()
    {
         rb = GetComponent<Rigidbody>();
        bullet_fire();
    }

    void Update()
    {

    }  

    public void bullet_fire()
    {
        rb.velocity = rb.transform.forward * speed;
        Invoke("fire_ball_destroy" , 2f);
    }
    public void fire_ball_destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boss"))
        {
           
            Boss_fight bossfight = other.GetComponentInParent<Boss_fight>();
            Vector3 dir = (other.transform.position - transform.position).normalized;
           // StartCoroutine(bossfight.Knockback(dir, 15f, 0.2f));
            UI_Manager.instance.update_health(0.009f);

        }

        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Audio_Manager.instance.enemy_die_Sfx();
        }
    }
}
