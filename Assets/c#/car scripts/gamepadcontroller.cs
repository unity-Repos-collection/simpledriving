using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class gamepadcontroller : MonoBehaviour
{
    
    // Start is called before the first frame update
    [Range(30.0f, 80.0f)]
    public float speed;
    [SerializeField] float speedGainPerSecond = 0.2f; 
    [SerializeField] float rotatespeed = 1f;
    Rigidbody rb;
    GameObject brakelight; 
    void Awake() 
    {
        
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        restart();
        mainmenu();
    }

    void FixedUpdate() 
    {   
        triggers();
        leftthumbstick();
        
    }
    void triggers()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        //right trigger
        if (gamepad.rightTrigger.IsPressed())
        {
            //Debug.Log("right trigger pressed");
            speed += speedGainPerSecond * Time.deltaTime;
            rb.AddRelativeForce(Vector3.forward * speed);
        }
        else if (!gamepad.rightTrigger.IsPressed())
        {
            speed -= speedGainPerSecond * Time.deltaTime;
        }
        //left trigger
        if (gamepad.leftTrigger.IsPressed())
        {
            //Debug.Log("left trigger pressed");
            //speed -= speedGainPerSecond * Time.deltaTime;
            rb.AddRelativeForce(Vector3.back * speed);
        }
    }

    void leftthumbstick()
    {   

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; 
        if (gamepad.leftStick.left.IsPressed())
        {
            //Debug.Log("left");
            Quaternion deltaRotation = Quaternion.Euler(Vector3.down * rotatespeed * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        else if (gamepad.leftStick.right.IsPressed())
        {
            brakelights();
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotatespeed * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
    void restart()
    {   
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;
        if (gamepad.selectButton.IsPressed())
        {
            Debug.Log("button pressed");
            int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(CurrentSceneIndex);
        }
    }

    void mainmenu()
    {   
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;
        if (gamepad.startButton.IsPressed())
        {
            SceneManager.LoadScene(0);   
        }
    }

    void brakelights()
    {
        
    }
}
