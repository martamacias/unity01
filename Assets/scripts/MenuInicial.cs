using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuInicial : MonoBehaviour
{
    public AudioSource play;
    public AudioSource clickQuit;
    public AudioSource clickSound;
    
    public void Play()
    {
        play.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        clickQuit.Play();
        Application.Quit();
    }
    public void SoundOnOff()
    {
        clickSound.Play();
    }
}
