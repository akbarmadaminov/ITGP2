using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HitScan : MonoBehaviour
{
    public Camera Camera;
    public LayerMask LayerMask;

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit, float.MaxValue, LayerMask)) return;
            Destroy(hit.transform.gameObject);
        }
        
    }
}
