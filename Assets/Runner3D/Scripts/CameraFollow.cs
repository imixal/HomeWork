using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position;
    }

    private void Update()
    {
        transform.position = target.transform.position + offset;
       
    }
}


