using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] 
    private float directForce;
    [SerializeField]
    private float turnForce;
    
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _rigidbody.AddForce(0, 0 ,directForce * Time.fixedTime);
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(turnForce * Time.fixedTime, 0 ,directForce );
        }

        else if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(-turnForce * Time.fixedTime, 0,directForce);
        }
    }
}


    