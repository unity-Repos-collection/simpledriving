using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardhandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 1f;
    [SerializeField] float speedGainPerSecond = 0.2f;
    [SerializeField] float rotatespeed = 1f;
    Rigidbody Rb;
    public float keyaccelvalue;
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate() 
    {
        handleforward();
        handlerotation();
    }
    void handleforward() 
    {   
        bool keyaccelvalue = Input.GetKey(KeyCode.W);
        bool reverseval = Input.GetKey(KeyCode.S);
        if (keyaccelvalue)
        {   
            //Debug.Log("w key pressed");
            speed += speedGainPerSecond * Time.deltaTime;
            Rb.AddRelativeForce(Vector3.forward * speed);
        }
        else if (!keyaccelvalue)
        {
            speed -= speedGainPerSecond * Time.deltaTime;
        }
        if (reverseval)
        {
            //Debug.Log("s key pressed");
            //speed -= speedGainPerSecond * Time.deltaTime;
            Rb.AddRelativeForce(Vector3.back * speed);
        }
    }

    void handlerotation()
    {   
        bool leftsteervalue = Input.GetKey(KeyCode.A);
        bool rightsteervalue = Input.GetKey(KeyCode.D);
        if (leftsteervalue)
        {
            //Debug.Log("a key pressed");
            Quaternion deltaRotation = Quaternion.Euler(Vector3.down * rotatespeed * Time.fixedDeltaTime);
            Rb.MoveRotation(Rb.rotation * deltaRotation);
            
        }        
        if (rightsteervalue)
        {
            //Debug.Log("d key pressed");
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotatespeed * Time.fixedDeltaTime);
            Rb.MoveRotation(Rb.rotation * deltaRotation);
        }
    }


}


