using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll_jumpscare : MonoBehaviour
{

    public static Doll_jumpscare Instance;


    public GameObject doll_jumpscare;

    
    // Start is called before the first frame update

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
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
    public void  activeejumpscare()
    {

    } 


}
