using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public static UI_Manager instance;
  //  public TextMeshProUGUI boss_health;
    public float boss_health_numbers = 1f; 
    public Slider boss_health_slider;
    public Slider Player_health_slider;
    public GameObject hand_uii;
    public GameObject pause_resmume_panel;


    //NPC dialogue

    public GameObject[] NPC_1;

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

    void Update()
    {
        if(Player_health_slider.value == 0f)
        {
            Scene_Manager.instance.Scene_Managerr();
        }

        if(boss_health_slider.value == 0f)
        {
            Scene_Manager.instance.Starting_Game();
        }
    }

    public void update_health(float deducew_boss_health)
    {
        boss_health_numbers -= deducew_boss_health;
        boss_health_slider.value -= deducew_boss_health;
        UpdateHealthtxt();
    }

    public void UpdateHealthtxt()
    {
       // boss_health.text = "Health" + boss_health_numbers;
        Debug.Log(boss_health_slider.value);    
    }


    public void update_player_health(float deduce_player_health)
    {
        Player_health_slider.value -= deduce_player_health;
    }
    public void heal_health(float heal)
    {
        Player_health_slider.value += heal;
    }

    public void npc_talk()
    {
        StartCoroutine(npc_explaining());
    }
    public void hand_ui()
    {
        hand_uii.SetActive(true);
    }
    public void toggle_hand_ui()
    {
        hand_uii.SetActive(false);
    }

    public void pause_game()
    {
        
        Time.timeScale = 0.0f;
        pause_resmume_panel.SetActive(true);
    }
    public void resume_game()
    {
        Time.timeScale = 1.0f;
        pause_resmume_panel.SetActive(false);
    }
 
    IEnumerator npc_explaining()
    {
        NPC_1[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        NPC_1[0].SetActive(false);
        NPC_1[1].SetActive(true);
        yield return new WaitForSeconds(2f);
        NPC_1[1].SetActive(false);
        NPC_1[2].SetActive(true);
        yield return new WaitForSeconds(2f);
        NPC_1[2].SetActive(false);
        NPC_1[3].SetActive(true);
        yield return new WaitForSeconds(2f);
        NPC_1[3].SetActive(false);
        NPC_1[4].SetActive(true);
        yield return new WaitForSeconds(2f);
        NPC_1[4].SetActive(false);
        NPC_1[5].SetActive(true);
        yield return new WaitForSeconds(2f);
        NPC_1[5].SetActive(false);
        NPC_1[6].SetActive(true);
        yield return new WaitForSeconds(2f);
        NPC_1[6].SetActive(false);
        NPC_1[7].SetActive(true);
        yield return new WaitForSeconds(2f);
        NPC_1[7].SetActive(false);
        NPC_1[8].SetActive(true);
        yield return new WaitForSeconds(2f);
        NPC_1[8].SetActive(false);
        NPC_1[9].SetActive(true);
        yield return new WaitForSeconds(2f);
        NPC_1[9].SetActive(false);
   
    }

}
