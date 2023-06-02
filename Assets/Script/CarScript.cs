using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    private float moveSpeed = 5000;
    private Rigidbody rb;
    private float gravityScalee = 5000;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        

    }
    
 
    public void CarMove()
    {
        rb.AddForce(Vector3.back * moveSpeed, ForceMode.Force);
        rb.AddForce(Physics.gravity * gravityScalee * Time.fixedDeltaTime, ForceMode.Force);
    }
}
