using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

     public GameObject pauseMenu;
     public  bool GameIsPaused;
    // Start is called before the first frame update
    void Start()
    {
        GameIsPaused= false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
               
            }
            else
            {
                Pause();
               
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
     
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    

      public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
    }
        public void Restart()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         GameIsPaused = false;
         Time.timeScale = 1f;
    }


         public void QuitGame()
    {
        Application.Quit();
    }
}
