using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {


  ///  public GameObject pausePanel;
   /// public GameObject pauseButton;
   /// 

    void Start()
    {
        
    }

    //Load Main Menu
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    //Load Game Over Scene
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    //Quit Game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Load Game over Scene after delay
    public  void LoadGameOverAfterDelay()
    {
        Invoke("LoadGameOver", 3.5f);
    }

    //Pause Level
    public void PauseLevel()
    {
        Time.timeScale = 0;
    }

    //Unpause Game
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    //Load Current Level
    public void LoadCurrentLevel()
    {
        var currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    //Load Next Level
    public void LoadNextLevel()
    {
        var currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex+1);
    }



}
