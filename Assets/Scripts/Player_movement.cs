using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Terresquall;

public class Player_movement : MonoBehaviour
{
    // Start is called before the first frame update


    enum playerstate
    {
       mobile,
       pc
    };


    public static Player_movement instance;
    private void Awake()
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


    //jump
    public float jump_speed = 1f;
    public bool isjump;
    public Transform ground_Check;
    public float ground_radius = 1.0f;
    public LayerMask groundlayer;
    public LayerMask wallLayer;
    bool isgrounded;


    //dash
    public float dash_speed_time = 0;
    public float Next_dash_time = 4f;
    public float dash_speed = 1.0f;
    bool isdashing;




    public float speed = 1.0f;


    //jump_buffer

    public float jump_bufferr = 0.15f;
    public float jump_buffer_countdown;


    //coyote_time
    public float coyotetime = 0.15f;
    public float coyotetimecountdown;


    //wall_check

    public float wallslide_amount;
    public float wall_check_distance;
    bool istouchingwall;
    bool istouchingwall_left;
    bool istouchingwall_right;
    bool istouchingwall_up;
    bool istouchingwall_down;


    Rigidbody rb;

    public Vector3 axis;

    //weopans
    public GameObject weopen1_shotgun;
    public GameObject weopen2_staff;
    public GameObject weopen2_staff_ui;
    public GameObject doll;
    //knockback
    public float knockback_force = 5f;

    bool can_talk = false;
    bool hasStartedDialogue = false;
    public GameObject llight;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Time.time > dash_speed_time && (Input.GetKeyDown(KeyCode.LeftShift) || mobile_input.instance.isdash))
        {
            StartCoroutine(Dash_timer());
            mobile_input.instance.isdash = false;
        }
       
        movement();

       

        if (Input.GetKeyDown(KeyCode.Z) || mobile_input.instance.isweopenchange)
        {
            weopen1_shotgun.SetActive(!weopen1_shotgun.activeSelf);
            weopen2_staff.SetActive(!weopen2_staff.activeSelf);
            weopen2_staff_ui.SetActive(!weopen2_staff_ui.activeSelf);
            mobile_input.instance.isweopenchange = false;
        }

        if(can_talk && !hasStartedDialogue )
        {
            hasStartedDialogue = true;
            Audio_Manager.instance.Radio();


            llight.SetActive(true);
            doll.SetActive(true);
            StartCoroutine(NPC_dialogues());
        }
        jump_buffer();
    }
   IEnumerator NPC_dialogues()
    {
        yield return new WaitForSeconds(3f);
        NPC_system.instance.talktoNPC1();
        yield return new WaitForSeconds(18f);
        llight.SetActive(false);
        doll.SetActive(false);
        can_talk = false;
    
    }
     
    public void movement()
    {
        
        
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");

            Vector2 input = new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical")
            );



            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;
            Vector2 joy = VirtualJoystick.GetAxis();
            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();

            Vector2 finalInput = input + joy;
            //   Debug.Log(finalInput);

            if (finalInput.magnitude > 0.2f)
            {
                Audio_Manager.instance.walking_skx();
                //    Audio_Manager.instance.randomwalk_pitch();
            }

            else
            {
                Audio_Manager.instance.walking_skx_sstop();
            }

            axis = (forward * finalInput.y + right * finalInput.x).normalized;
        
    }

    public void Dash()
    {
        Vector3 Dash_Direction = transform.forward;
        rb.velocity = new Vector3(Dash_Direction.x * dash_speed, Dash_Direction.y, Dash_Direction.z * dash_speed);
        //Debug.Log("Dash_used" + " speed" + dash_speed);
    }

    IEnumerator Dash_timer()
    {
        isdashing = true;
        Dash();
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
        yield return new WaitForSeconds(0.5f);
        dash_speed_time = Time.time + Next_dash_time;
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
        isdashing = false;
    }

    public void jump_buffer()
    {
        if (Input.GetKeyDown(KeyCode.Space) || mobile_input.instance.isjumped)
        {
            isjump = true;
            mobile_input.instance.isjumped = false;
            jump_buffer_countdown = jump_bufferr;
        }
        else
        {
            jump_buffer_countdown -= Time.deltaTime;
        }
    }
    public void coyotetimefn()
    {
        if (isgrounded)
        {
            isjump = true;
            mobile_input.instance.isjumped = false;
            coyotetimecountdown = coyotetime;
        }
        else
        {

            coyotetimecountdown -= Time.fixedDeltaTime;
        }
    }

    public void FixedUpdate()
    {
        isgrounded = Physics.OverlapSphere(ground_Check.transform.position, ground_radius, groundlayer).Length > 0;
        coyotetimefn();
        wall_check();
      
         
        if (!isdashing)
        {
            rb.velocity = new Vector3(axis.x * speed, rb.velocity.y, axis.z * speed);
        }


        wallslide();

        if ( jump_buffer_countdown > 0 && coyotetimecountdown > 0 )
        {
            rb.velocity = new Vector3(rb.velocity.x, jump_speed, rb.velocity.z);
           // Debug.Log("it jump" + jump_speed);
            isjump = false;
            jump_buffer_countdown = 0;
            coyotetimecountdown = 0;
        }
    }

    public void wall_check()
        {
        Vector3 origin = transform.position + Vector3.up * 1f;
        RaycastHit hitleft;
        RaycastHit hitright;
        RaycastHit hitfront;
        RaycastHit hitback;

        bool left = Physics.Raycast(origin, -transform.right, out hitleft, wall_check_distance, wallLayer); 
        bool right = Physics.Raycast(origin, transform.right,out hitright ,wall_check_distance,wallLayer);
        bool front  = Physics.Raycast(origin, transform.forward,out hitfront,wall_check_distance,wallLayer);
        bool back = Physics.Raycast(origin , -transform.forward,out hitback,wall_check_distance,wallLayer);   

       // Debug.DrawRay(origin, -transform.right * 50, Color.red);
       // Debug.DrawRay(origin, transform.right * 50, Color.blue);
        //Debug.DrawRay(origin, -transform.forward * 50, Color.green);
       // Debug.DrawRay(origin, transform.forward * 50, Color.yellow);

        //istouchingwall_left = hitleft.collider != null;
        //istouchingwall_right = hitright.collider != null;
        //istouchingwall_up = hitfront.collider != null;
        //istouchingwall_down = hitback.collider != null;
        
        if(left)
        {
            //Debug.Log("istouching_left");
        }
        if (right)
        {
          //  Debug.Log("istouching_right");
        }
        if (front)
        {
          //  Debug.Log("is touching_up");

        }
        if (back)
        {
           // Debug.Log("istouching_down");
        }

        istouchingwall = left || right ;


    }
     
    public void wallslide()
    {
        if (istouchingwall && !isgrounded && rb.velocity.y < 0)
        {
            rb.velocity = new Vector3(0 , -wallslide_amount , 0);
        }
    }

    public void knockback(Vector3 dir)
    {
        rb.AddForce(dir * knockback_force  , ForceMode.Impulse);   
    }

     










    //trigerred stuff
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss_Enter_area"))
        {
            Spawn_Manager.instance.active_boss();
            Audio_Manager.instance.Boss_fight_music();
        }

        if (other.CompareTag("NM_1"))
        {
            Spawn_Manager.instance.active_Enemey_1_wave();
        }

        if (other.CompareTag("NM_2"))
        {
            Spawn_Manager.instance.active_Enemey_2_wave();
        }

        if (other.CompareTag("NM_3"))
        {
            Spawn_Manager.instance.active_Enemey_3_wave();
        }

        if (other.CompareTag("NM_4"))
        {
            Spawn_Manager.instance.active_Enemey_4_wave();
        }

        if (other.CompareTag("NM_5"))
        {
            Spawn_Manager.instance.active_Enemey_5_wave();
        }

        if (other.CompareTag("jump_scare"))
        {
            Spawn_Manager.instance.Jump_scare();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("NPC") )
        {
            can_talk = true;
        }
    }

   



    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("NPC") )
    //    {
    //      //  NPC_system.instance.exittalk_to_NPC();
    //        can_talk = false;
    //    }

    //}
}