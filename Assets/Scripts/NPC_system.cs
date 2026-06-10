using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_system : MonoBehaviour
{
    // Start is called before the first frame update

    public static NPC_system instance;
    public GameObject gameplay_camera;
    public GameObject NPC_camera;
    private void Awake()
    {
        if(instance == null)
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

    public void talktoNPC1()
    {

        UI_Manager.instance.npc_talk();

    }

    public void exittalk_to_NPC()
    {
    
      
    }
}
