using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRagdoll : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<DieAsRagdoll>() != null)
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<DieAsRagdoll>().hit = true;
        }
    }
}
