using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject prototype;
    public float speed = 30f;
    public Vector3 startPos;
    public Vector3 startPoint = Vector3.forward;
    
    public double time;
    public float Angle = 10f;
    
    private void Start()
    {
        startPos = transform.position;
        time = Time.timeAsDouble;
    }

    private void Update()
    {
        if ((Time.timeAsDouble - time) > 1.0)
        {
            time = Time.timeAsDouble;
            var targets = GameObject.FindGameObjectsWithTag("target");
            
            foreach (var target in targets)
            {
                var check = target.GetComponent<DieAsRagdoll>();
                if (check != null && check.hit == true) continue;
                
                Vector3 targetPos = target.GetComponent<Transform>().position;
                Vector3 direction = (targetPos - startPos).normalized;

                var dot = (Vector3.Dot(startPoint, direction) + 1) / 2;
                
                if (1f - dot > Angle / 180f) continue;
                
                // Rotating the Cannon
                Vector3 yDiffer = new Vector3(0, targetPos.y - 2, targetPos.z);
                Vector3 xDiffer = new Vector3(targetPos.x, 0, targetPos.z);
                
                float yAngle = Vector3.SignedAngle(Vector3.forward, yDiffer, Vector3.right) + 90;
                float xAngle = Vector3.SignedAngle(Vector3.forward, xDiffer, Vector3.up);
                transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
                ///////////////////
                
                GameObject projectile = Instantiate(prototype, transform.position, transform.rotation);
                projectile.GetComponent<Rigidbody>().velocity = direction * speed;
                break;
            }
        }
    }
}
