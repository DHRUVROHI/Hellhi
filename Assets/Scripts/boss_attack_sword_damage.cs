using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_attack_sword_damage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            UI_Manager.instance.update_player_health(0.1f);
            StartCoroutine(destroy_sword());
        }
    }
    IEnumerator destroy_sword()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
}
