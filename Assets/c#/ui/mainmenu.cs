using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    [SerializeField] AudioClip startupsound;
    [SerializeField] float startdelay = 4f;
    [SerializeField] bool start;
    [SerializeField] bool quit;
    AudioSource As;
    private void Awake() 
    {
        As = GetComponent<AudioSource>(); 
    }
    
    public void startgame(bool startvalue)
    {
        if(startvalue == true) 
        {   
            startsound();
            Debug.Log("ui button pressed");
            Invoke(nameof(startgame),startdelay); 
        } 
    }
    private void startgame()
    {
        SceneManager.LoadScene(1);
    }

    public void quitgame(bool quitvalue)
    {
        if(quitvalue == true) 
        {   
            startsound();
            Debug.Log("quit pressed");
            Application.Quit();           
        } 
    }
    public void openoptions(bool optionsvalue)
    {
        if(optionsvalue == true) 
        {   
            startsound();
            Debug.Log("options opening");
            Invoke(nameof(getoptionsscreen), startdelay);          
        } 
    }
    public void startsound()
    {   
        As.Stop();
        As.PlayOneShot(startupsound);
    }
    public void getoptionsscreen()
    {
        SceneManager.LoadScene(2);
    }
}
