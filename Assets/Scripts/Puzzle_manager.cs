using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_manager : MonoBehaviour
{
    // Start is called before the first frame update

    public static Puzzle_manager instance;
    int vasecount = 0;
    public Animator sand_anim;
    bool completed = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Addvase()
    {
        if (completed) return;
        vasecount++;
        if (vasecount >= 3)
        {
            completed = true;
            sand_anim.SetTrigger("unlocked");
            Audio_Manager.instance.Rumble();
            Camera_shake.instance.shake(3, 9);


        }

    }
}
