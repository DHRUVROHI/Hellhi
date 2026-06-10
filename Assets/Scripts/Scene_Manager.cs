using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{

    public static Scene_Manager instance;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scene_Managerr()
    {
        SceneManager.LoadScene("Prototype");

    }
    public void Ending_Game()
    {
        SceneManager.LoadScene("ending");
    }
    public void Starting_Game()
    {
        SceneManager.LoadScene("Main_menu");
    }
    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Game Quit");
    }
}
