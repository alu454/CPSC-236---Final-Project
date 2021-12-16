using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Rigidbody physics;
    private float moveSpeed = 150;

    void Awake()
    {
        physics = gameObject.GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(6, 3);
        Physics.IgnoreLayerCollision(6, 6);
        Physics.IgnoreLayerCollision(6, 7);
        Physics.IgnoreLayerCollision(6, 8);
        Launch();
    }

    private void Launch()
    {
        physics.isKinematic = false;
        physics.AddForce(new Vector3(moveSpeed, Random.Range(-moveSpeed, moveSpeed), 0f));
    }
}
