using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
   public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
            
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }

        }
     
    }

    public void pauseGame()
    {
     pauseMenu.SetActive(true);
     Time.timeScale = 0.0f;
     isPaused = true;   
    } 

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;   
    }
}
