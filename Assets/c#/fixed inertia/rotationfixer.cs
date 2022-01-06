using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotationfixer : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;

    }
}
    

        
    
            
        
    

