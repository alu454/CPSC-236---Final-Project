using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    
    private Rigidbody physics;
    private float moveSpeed = 200;

    void Awake()
    {
        physics = gameObject.GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(7, 6);
        Physics.IgnoreLayerCollision(7, 3);
        Physics.IgnoreLayerCollision(7, 7);
        Physics.IgnoreLayerCollision(7, 8);
        Launch();
    }

    private void Launch()
    {
        physics.isKinematic = false;
        physics.AddForce(new Vector3(Random.Range(-moveSpeed, moveSpeed), Random.Range(-moveSpeed, moveSpeed), 0f));
    }

    
}
