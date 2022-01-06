using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class lvl_ui : MonoBehaviour
{
    
    private bool restart;
    private bool quit;

    //ui logic
    public void restartui(bool uivalue)
    {   
        restart = uivalue;
        if (uivalue == true)
        {   
            Debug.Log("restart button pressed");
            int SceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(SceneIndex);
            
        }    
    }
    public void quitui(bool quitvalue)
    {   
        quit = quitvalue;
        if(quitvalue == true) 
        {   
            Debug.Log("quit button pressed");
            SceneManager.LoadScene(0);
        }    
    }
}
