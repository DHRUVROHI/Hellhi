
using UnityEditor;
using UnityEngine;

public class Boss_sword_attack : MonoBehaviour
{
    public static Boss_sword_attack instance;
    // Start is called before the first frame update
    public Transform Player;
    public GameObject swordprefab;
    public Transform attackPoint;

    public float attackRange;


    public void Awake()
    {
        if (instance == null)
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

   public  void sword_attack()
    {
        GameObject sword  =  Instantiate(swordprefab, attackPoint.transform.position, Quaternion.Euler(-5.0f,-10.0f,5.0f));
        Rigidbody rb = sword.GetComponent<Rigidbody>(); 
        Vector3 direction = (Player.transform.position - attackPoint.transform.position).normalized;
        rb.velocity = direction * attackRange;
         
    }
}
