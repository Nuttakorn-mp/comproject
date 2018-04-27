using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermaneger : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public static bool GameInpaused = false;
    //bool lose = false;
    // Use this for initialization
    public GameObject pauseMenuUI;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool lose = p1.tag == "Die" && p2.tag == "Die";
        if (Input.GetKeyDown(KeyCode.Escape)|| lose== true)
        {
            
            if (GameInpaused && lose != true)
            {
                Resume();

            }
            else
            {
                pause();
            }
        }

    }
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameInpaused = false;
    }
    void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameInpaused = true;
    }
}
