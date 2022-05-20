using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject buttonPause;
    public GameObject menuPause;
    public GameObject scoreTxt;

    //private bool gamePaused = false;
    private void Update() {
        /*if(Input.GetKeyDown(KeyCode.Escape)){
            if (gamePaused) {
                Resume();
            } else {
                Pause();
            }
        }*/
    }
    public void Pause()
    {
        //gamePaused = true;
        Time.timeScale = 0f;
        buttonPause.SetActive(false);
        scoreTxt.SetActive(false);
        menuPause.SetActive(true);
    }
    public void Resume()
    {
        //gamePaused = false;
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        scoreTxt.SetActive(true);
        menuPause.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
