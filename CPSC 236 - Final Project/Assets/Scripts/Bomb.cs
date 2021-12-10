using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody physics;
    private float startSpeed = 300;

    void Awake()
    {
        physics = gameObject.GetComponent<Rigidbody>();
    }

    private void Launch()
    {
        physics.isKinematic = false;
        physics.AddForce(new Vector3(startSpeed, startSpeed, 0f));
    }
}
