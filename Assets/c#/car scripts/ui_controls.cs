using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_controls : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] private float speedGainPerSecond = 0.2f;
    public int steerValue;
    public int braking;
    public float accelerationvalue;
    Rigidbody rb;
    Vector3 m_EulerAngleVelocity;
    public Canvas canvas;
    // Start is called before the first frame update
    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        touchforward();
        touchrotate();    
    }
    public void brake(int brakevalue)
    {
        braking = brakevalue;
    }
    public void Steer(int value)
    {
        steerValue = value;
    }
    public void momentum(float accel)
    {
        accelerationvalue = accel;
    }
    private void touchforward()
    {   
        float xvector = 0f;
        float yvector = 0f;
        if(accelerationvalue == 1)
        {   
            speed += speedGainPerSecond * Time.deltaTime;
            rb.AddRelativeForce(xvector, yvector, accelerationvalue * speed);
        }
        else if (braking == 1) 
        {
            speed -= speedGainPerSecond * Time.deltaTime;
            rb.AddRelativeForce(xvector, yvector, accelerationvalue * speed);
        }
    }
    private void touchrotate()
    {   
        float Zangle = 0f;
        float Xangle = 0f;
        Quaternion deltaRotation = Quaternion.Euler(Xangle, steerValue ,Zangle * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}

