using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAsRagdoll : MonoBehaviour
{
    public bool hit = false;
    public bool done = false;

    private void Start()
    {
        var rigids = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in rigids)
        {
            rigidbody.isKinematic = true;
        }
    }

    private void Update()
    {
        if (hit && !done)
        {
            done = true;
            var rigids = GetComponentsInChildren<Rigidbody>();
            foreach (var rigidbody in rigids)
            {
                rigidbody.isKinematic = false;
            }
        }
    }
}
