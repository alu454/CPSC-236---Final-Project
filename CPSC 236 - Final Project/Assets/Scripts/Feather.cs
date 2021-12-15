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
        Launch();
    }

    private void Launch()
    {
        physics.isKinematic = false;
        physics.AddForce(new Vector3(Random.Range(-moveSpeed, moveSpeed), Random.Range(-moveSpeed, moveSpeed), 0f));
    }
}
