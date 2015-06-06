// Shatter Toolkit
// Copyright 2015 Gustav Olsson
using System.Collections.Generic;
using UnityEngine;

namespace ShatterToolkit.Examples
{
    [RequireComponent(typeof(Rigidbody))]
    public class RotateRigidbody : MonoBehaviour
    {
        public Vector3 axis = Vector3.up;
        
        public float angularVelocity = 7.0f;

        protected Rigidbody rb;

        public void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        
        public void FixedUpdate()
        {
            Quaternion deltaRotation = Quaternion.AngleAxis(angularVelocity * Time.fixedDeltaTime, axis);
            
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}