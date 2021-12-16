using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    
    private Rigidbody physics;
    private float startSpeed = 250;

    void Awake()
    {
        physics = gameObject.GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(3, 6);
        Physics.IgnoreLayerCollision(3, 7);
        Physics.IgnoreLayerCollision(3, 3);
        Physics.IgnoreLayerCollision(3, 8);
        Launch();
    }

    private void Launch()
    {
        physics.isKinematic = false;
        physics.AddForce(new Vector3(startSpeed, Random.Range(-startSpeed, startSpeed), 0f));
    }
}
