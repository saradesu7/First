using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    private int layer;
    private LayerMask layerMask;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        layerMask = LayerMask.GetMask("Archer");
        if (layerMask.value == 1<<layer)
            Debug.Log("heree");
        Debug.Log(layerMask);
        Destroy(gameObject);
    }
}
