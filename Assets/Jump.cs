using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float Velocity = 5;
    private Rigidbody _rigidbody;
    public float RaycastDistance = 3;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var ray = new Ray(transform.position, -transform.up);
        if (Input.GetButton("Jump") && Physics.Raycast(ray, RaycastDistance))
        {
            var velocity = _rigidbody.velocity;
            velocity.y = Velocity;
            _rigidbody.velocity = velocity;
        }
    }
}

