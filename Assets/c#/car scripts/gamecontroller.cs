using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
public class gamecontroller : MonoBehaviour
{   [SerializeField] private float delay = 3f;
    [SerializeField] AudioClip SuccessSound;
    [SerializeField] AudioClip italiansound;
    [SerializeField] ParticleSystem exhaustparticle;
    [SerializeField] ParticleSystem crashparticle;
    bool TimerOn;
    public Text counterText;
    public float seconds, minutes;
    
    public Canvas canvas;
    AudioSource As;
    void Awake()
    {   
        As = GetComponent<AudioSource>();  
    }
    void Start()     
    {   
        TimerOn = false;
        Text counterText = GetComponent<Text>();
        
        Startexhausteffect();
        disableui();
        Invoke(nameof(enableiu),delay);
    }

    void Update()
    {   
    }

    

    //game logic
    private void OnTriggerEnter(Collider collider) 
    {
        switch (collider.gameObject.tag)
        {      
            case "obsticle":
                Debug.Log("Hit obsticle");
                playitaliansound();
                startcrasheffect();
                Invoke(nameof(reloadlevel),delay);
                break;
            
            case "startline":
                playitaliansound();
                starttimer();
                Debug.Log("start");
                TimerOn = true;
                break;
        
            case "finish":
                Debug.Log("Hit Finish");
                TimerOn = false;
                playwinsound();
                Invoke(nameof(NextLevel), delay);
                break;
        }
    }
    
    //scene array mods
    public void reloadlevel()
    {   
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
    
    public void NextLevel()
    {   
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextSceneIndex = CurrentSceneIndex + 1;
        
        if (NextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextSceneIndex = 0;    
        } 
        SceneManager.LoadScene(NextSceneIndex);
    }
    
    void starttimer()
    {   
        //minutes = (int)(Time.deltaTime / 60f);
        seconds = (int)(Time.deltaTime);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    
    //sounds
    void playwinsound()
    {
        As.Stop();
        As.PlayOneShot(SuccessSound);
    }
    void playitaliansound()
    {
        As.Stop();
        As.PlayOneShot(italiansound);
    }
    //ParticleSystem effects
    void Startexhausteffect()
    {
        exhaustparticle.Play();
    }
    void startcrasheffect()
    {
        crashparticle.Play();
    }
    //disable/enable ui
    private void disableui()
    {
        canvas.enabled = false;
    }
    private void enableiu()
    {
        canvas.enabled = true;
    } 
}






