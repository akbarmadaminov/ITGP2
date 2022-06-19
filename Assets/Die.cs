using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "projectile")
        {
            Destroy(gameObject); 
        }
    }
}
